using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization.Configuration;
using TrackAssist.Contracts;
using TrackAssist.Contracts.Data;
using TrackAssist.Contracts.Enums;
using TrackAssist.Contracts.Plugins;
using TrackAssist.Data.Factories;
using TrackAssist.Shared.Charting;
using TrackAssist.Shared.ViewModels;
using TrackAssist.ViewModels;

namespace TrackAssist.Widgets.Charts.EstimatedAndElapsedByUser
{
    public class EstimatedAndElapsedByUserChart : IPluggable, IChartWidget
    {
        public ChartType ChartType { get { return ChartType.SparrowColumn; } }
        public Guid Identifier { get; private set; }
        public string Title { get { return "Estimated Progress by User"; } }
        public string SubTitle { get { return "How far along is everyone?"; } }

        public ChartDataViewModel GetData(IEnumerable<CaseViewModel> visibleCases, IEnumerable<IntervalViewModel> intervals, IGenericDataSeriesFactory dataFactory)
        {
            var series = dataFactory.CreateGrouped(visibleCases, c => c.AssignedTo,
                new List<GroupedSeriesValueConfig<CaseViewModel>>
                {
                    new GroupedSeriesValueConfig<CaseViewModel>
                    {
                        Name = "Estimated",
                        ValueSelector = (c) => c.EstimatedTime
                    },
                    new GroupedSeriesValueConfig<CaseViewModel>
                    {
                        Name = "Elapsed",
                        ValueSelector = (c) => c.ElapsedTime
                    }
                });

            return new ChartDataViewModel
            {
                Title = Title,
                SubTitle = SubTitle,
                Series = new ObservableCollection<SeriesViewModel>(series),
                ChartType = ChartType
            };
        }
    }
}
