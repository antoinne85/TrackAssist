using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using De.TorstenMandelkow.MetroChart;
using FogBugzApiWrapper;
using FogBugzApiWrapper.Data;
using TrackAssist.Adapters;
using TrackAssist.Contracts;
using TrackAssist.Contracts.Enums;
using TrackAssist.Contracts.Plugins;
using TrackAssist.Data.Factories;
using TrackAssist.Serialization;
using TrackAssist.ViewModels;
using TrackAssist.Widgets.Charts;
using TrackAssist.Widgets.Charts.CasesWithoutEstimatesByUser;
using TrackAssist.Widgets.Charts.EstimatedAndElapsedByUser;
using TrackAssist.Widgets.Charts.EstimatedTimeByUser;
using TrackAssist.Widgets.Milestones;
using TrackAssist.Widgets.Users;
using Xceed.Wpf.AvalonDock.Layout;

namespace TrackAssist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var endpoint = ConfigurationManager.AppSettings["FogbugzApiEndpoint"];
            var api = new FogBugzApi(endpoint, new GenericFogBugzRequestUriBuilder());
            var seriesFactory = new GenericDataSeriesFactory(new DataPointFactory());
            var filterFactory = new BasicFilterFactory();
            var serializer = new GenericJsonSerializer();
            var chartAdapter = new SparrowChartsAdapter();
            var vm = new MainViewModel(api, seriesFactory, filterFactory, serializer, chartAdapter);
            this.DataContext = vm;

            foreach (var pluggableComponent in GetUiComponents())
            {
                if (pluggableComponent is IRegisterableFilterSource)
                {
                    vm.RegisterFilterSource(pluggableComponent as IRegisterableFilterSource);
                }

                if (pluggableComponent is IPluggableUi)
                {
                    var pluggableUi = pluggableComponent as IPluggableUi;
                    pluggableUi.RegistrationCallback(api);
                    WidgetArea.Children.Add(new LayoutAnchorable
                    {
                        Title = pluggableUi.Name,
                        Content = pluggableUi.UiElement
                    });
                }

                if (pluggableComponent is IChartWidget)
                {
                    var chartWidget = pluggableComponent as IChartWidget;
                    var chartUi = chartAdapter.Create(chartWidget.ChartType);
                    var chartVm = new ChartConnection
                    {
                        DataGenerationFunction = (visibleCases, visibleIntervals, dataFactory) => chartWidget.GetData(visibleCases, visibleIntervals, dataFactory)
                    };
                    chartUi.DataContext = chartVm;
                    ChartArea.Children.Add(chartUi);
                    vm.RegisterChart(chartVm);
                }

                if (pluggableComponent is IConfigurable)
                {
                    vm.RegisterConfigurable(pluggableComponent as IConfigurable);
                }
            }
        }

        public List<IPluggable> GetUiComponents()
        {
            return new List<IPluggable>
            {
                new UserFilter(),
                new MilestonesFilter(),
                new EstimatedTimeByUserChart(),
                new EstimatedAndElapsedByUserChart(),
                new CasesWithoutEstimatesByUserChart(),
                new TimesheetChart()
            };
        }
    }
}
