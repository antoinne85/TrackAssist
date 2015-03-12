using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using FogBugzApiWrapper;
using TrackAssist.Adapters;
using TrackAssist.Annotations;
using TrackAssist.Commands;
using TrackAssist.Contracts;
using TrackAssist.Contracts.Data;
using TrackAssist.Contracts.Plugins;
using TrackAssist.Data.Factories;
using TrackAssist.Serialization;
using TrackAssist.Shared.Charting;
using TrackAssist.Shared.ViewModels;
using TrackAssist.Widgets.Charts;

namespace TrackAssist.ViewModels
{
    public class MainViewModel
    {
        private readonly IFogBugzApi _fogBugzApi;
        private readonly IGenericDataSeriesFactory _dataSeriesFactory;
        private readonly IBasicFilterFactory _filterFactory;
        private readonly IGenericJsonSerializer _serializer;
        private readonly IChartAdapter _chartAdapter;

        public MainViewModel(IFogBugzApi fogBugzApi, IGenericDataSeriesFactory dataSeriesFactory, IBasicFilterFactory filterFactory, IGenericJsonSerializer serializer,
            [NotNull] IChartAdapter chartAdapter)
        {
            if (fogBugzApi == null)
            {
                throw new ArgumentNullException("fogBugzApi");
            }

            if (dataSeriesFactory == null)
            {
                throw new ArgumentNullException("dataSeriesFactory");
            }

            if (filterFactory == null)
            {
                throw new ArgumentNullException("filterFactory");
            }

            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            if (chartAdapter == null)
            {
                throw new ArgumentNullException("chartAdapter");
            }

            _fogBugzApi = fogBugzApi;
            _dataSeriesFactory = dataSeriesFactory;
            _filterFactory = filterFactory;
            _serializer = serializer;
            _chartAdapter = chartAdapter;

            AvailableData = new AvailableDataViewModel(_fogBugzApi);
            Chart = new ChartConnection();
            FilterSources = new List<IRegisterableFilterSource>();
            ChartConnections = new List<ChartConnection>();
            Configurables = new List<IConfigurable>();
            FilteredCases = new ObservableCollection<CaseViewModel>();
            Charts = new List<ChartConnection>();
            FilteredIntervals = new ObservableCollection<IntervalViewModel>();
            Initialize();
        }

        public List<IConfigurable> Configurables { get; set; }

        public void RegisterFilterSource(IRegisterableFilterSource filterSource)
        {
            FilterSources.Add(filterSource);
        }

        public void RegisterChartWidget(IChartWidget chartWidget)
        {
            var connection = new ChartConnection
            {
                DataGenerationFunction = chartWidget.GetData,
                ViewModel = new object()
            };
            ChartConnections.Add(connection);
        }

        public void RegisterChart(ChartConnection chartWidget)
        {
            Charts.Add(chartWidget);
        }

        private List<ChartConnection> Charts { get; set; }

        public List<IRegisterableFilterSource> FilterSources { get; set; }
        public List<ChartConnection> ChartConnections { get; set; } 
        public ObservableCollection<CaseViewModel> FilteredCases { get; set; } 

        private void Initialize()
        {
            var username = ConfigurationManager.AppSettings["FogbugzApiUsername"];
            var password = ConfigurationManager.AppSettings["FogbugzApiPassword"];
            _fogBugzApi.Login(username, password);
            AvailableData.Initialize();

            Refresh = new DelegateCommand((param) => Filter());
            SaveConfigurations = new DelegateCommand((param) => SaveConfigs());
            LoadConfigurations = new DelegateCommand((param) => ApplyConfigs());
            foreach (var fbCase in AvailableData.Cases)
            {
                FilteredCases.Add(fbCase);
            }

            foreach (var interval in AvailableData.Intervals)
            {
                FilteredIntervals.Add(interval);
            }

            NotifyCharts();
        }

        private void SaveConfigs()
        {
            var configurations = new Dictionary<Guid, string>();
            foreach (var configurable in Configurables)
            {
                var config = configurable.GetConfiguration();
                configurations[configurable.Identifier] = _serializer.Serialize(config);
            }

            var json = _serializer.Serialize(configurations);
            File.WriteAllText("config.json", json);
        }

        private void ApplyConfigs()
        {
            var configurations = LoadConfigsFromDisk();
            foreach (var kvp in configurations)
            {
                var targetPluggable = Configurables.FirstOrDefault(c => c.Identifier == kvp.Key);
                if (targetPluggable != null)
                {
                    //Get the type, it's interface and it's generic parameter.
                    var type = targetPluggable.GetType();

                    var configurableInterface = type.GetInterfaces()
                        .FirstOrDefault(i => i.IsGenericType);
                    var genericArgument = configurableInterface.GetGenericArguments()[0];

                    //Deserialize it all special like.
                    var serializerType = _serializer.GetType();
                    var serializerMethod = serializerType.GetMethod("Deserialize");
                    var genericSerializerMethod = serializerMethod.MakeGenericMethod(genericArgument);
                    var deserializedObject = genericSerializerMethod.Invoke(_serializer, new object[]{kvp.Value});
                    targetPluggable.ApplyConfiguration(deserializedObject);
                }
            }
        }

        private Dictionary<Guid,string> LoadConfigsFromDisk()
        {
            var json = File.ReadAllText("config.json");
            return _serializer.Deserialize<Dictionary<Guid, string>>(json);
        }

        private void NotifyCharts()
        {
            var cases = FilteredCases.ToList();
            var intervals = FilteredIntervals.ToList();
            foreach (var chart in Charts)
            {
                var data = chart.DataGenerationFunction(cases, intervals, _dataSeriesFactory);
                chart.ViewModel = _chartAdapter.Adapt(data);
            }
        }

        public ICommand Refresh { get; set; }
        public ICommand SaveConfigurations { get; set; }
        public ICommand LoadConfigurations { get; set; }

        private void Filter()
        {
            var casesChanged = FilterCases();
            var intervalsChanged = FilterIntervals();

            if (casesChanged || intervalsChanged)
            {
                NotifyCharts();
            }
        }

        private bool FilterIntervals()
        {
            var resultIntervals = AvailableData.Intervals.Select(c => c);
            foreach (var filter in FilterSources)
            {
                var filterFunction = filter.GetIntervalFilterFunction(_filterFactory);
                if (filterFunction != null)
                {
                    resultIntervals = filterFunction.Invoke(resultIntervals);
                }
            }

            var intervalsToRemove = FilteredIntervals.Except(resultIntervals).ToList();
            var intervalsToAdd = resultIntervals.Except(FilteredIntervals).ToList();
            foreach (var interval in intervalsToRemove)
            {
                FilteredIntervals.Remove(interval);
            }

            foreach (var interval in intervalsToAdd)
            {
                FilteredIntervals.Add(interval);
            }

            if (intervalsToRemove.Any() || intervalsToAdd.Any())
            {
                return true;
            }

            return false;
        }

        private bool FilterCases()
        {
            var resultCases = AvailableData.Cases.Select(c => c);
            foreach (var filter in FilterSources)
            {
                var filterFunction = filter.GetCaseFilterFunction(_filterFactory);
                if (filterFunction != null)
                {
                    resultCases = filterFunction.Invoke(resultCases);
                }
            }

            var casesToRemove = FilteredCases.Except(resultCases).ToList();
            var casesToAdd = resultCases.Except(FilteredCases).ToList();
            foreach (var fbCase in casesToRemove)
            {
                FilteredCases.Remove(fbCase);
            }

            foreach (var fbCase in casesToAdd)
            {
                FilteredCases.Add(fbCase);
            }

            if (casesToRemove.Any() || casesToAdd.Any())
            {
                return true;
            }

            return false;
        }

        public AvailableDataViewModel AvailableData { get; set; }
        public ChartConnection Chart { get; set; }
        public ObservableCollection<IntervalViewModel> FilteredIntervals { get; set; } 

        public void RegisterConfigurable(IConfigurable configurable)
        {
            Configurables.Add(configurable);
        }
    }

    public class AvailableDataViewModel
    {
        private readonly IFogBugzApi _fogBugzApi;

        public AvailableDataViewModel(IFogBugzApi fogBugzApi)
        {
            if (fogBugzApi == null)
            {
                throw new ArgumentNullException("fogBugzApi");
            }
            _fogBugzApi = fogBugzApi;

            Users = new List<UserViewModel>();
            Milestones = new List<MilestoneViewModel>();
            Cases = new List<CaseViewModel>();
            Intervals = new List<IntervalViewModel>();
        }

        public List<CaseViewModel> Cases { get; set; }
        public List<UserViewModel> Users { get; set; }
        public List<MilestoneViewModel> Milestones { get; set; }
        public List<IntervalViewModel> Intervals { get; set; } 

        public void Initialize()
        {
            Users = _fogBugzApi.ListUsers().Select(u => new UserViewModel
            {
                Name = u.Name,
                Id = u.Id
            }).ToList();

            Cases = _fogBugzApi.ListCases().Select(c => new CaseViewModel
            {
                AssignedTo = c.AssignedToUserName,
                Milestone = c.MilestoneName,
                Title = c.Title,
                Number = c.CaseId,
                EstimatedTime = c.CurrentEstimateInHours.Value,
                ElapsedTime = c.ElapsedHours.Value
            }).ToList();

            var userLookup = Users.ToDictionary(u => u.Id, u => u.Name);

            
            Intervals = _fogBugzApi.ListIntervals().Where(i => i.EndTime.HasValue).Select(i => new IntervalViewModel
            {
                Username = userLookup[i.UserId],
                StartDate = i.StartTime,
                EndDate = i.EndTime.Value
            }).ToList();
        }
    }
}
