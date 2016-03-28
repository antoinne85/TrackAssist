using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using FogBugzApiWrapper;
using TrackAssist.Contracts;
using TrackAssist.Contracts.Data;
using TrackAssist.Contracts.Enums;
using TrackAssist.Contracts.Plugins;
using TrackAssist.Data.Factories;
using TrackAssist.Shared.Charting;
using TrackAssist.Shared.ViewModels;
using TrackAssist.ViewModels;

namespace TrackAssist.Widgets.Charts.EstimatedTimeByUser
{
    public class EstimatedTimeByUserChart : IPluggable, IChartWidget
    {
        public string Title { get { return "Estimated Hours by User"; } }
        public string SubTitle { get { return "How much work is on everyone's plate?"; } }
        public ChartType ChartType { get{ return ChartType.SparrowColumn; } }
        public ChartDataViewModel GetData(IEnumerable<CaseViewModel> visibleCases, IEnumerable<IntervalViewModel> intervals, IGenericDataSeriesFactory dataFactory)
        {
            var chartData = dataFactory.CreateGrouped(visibleCases, c => c.AssignedTo, new List<GroupedSeriesValueConfig<CaseViewModel>>
            {
              new GroupedSeriesValueConfig<CaseViewModel>
              {
                Name = "Estimated Hours",
                ValueSelector = c => c.EstimatedTime
              }
            });
            return new ChartDataViewModel
            {
                Title = Title,
                SubTitle = SubTitle,
                Series = new ObservableCollection<SeriesViewModel>(chartData),
                ChartType = ChartType
            };
        }
        
        public Guid Identifier { get; private set; }
        
    }
}
