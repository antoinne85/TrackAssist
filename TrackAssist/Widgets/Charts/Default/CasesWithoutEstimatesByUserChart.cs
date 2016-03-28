using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TrackAssist.Contracts.Data;
using TrackAssist.Contracts.Plugins;
using TrackAssist.Shared.Charting;
using TrackAssist.Shared.ViewModels;

namespace TrackAssist.Widgets.Charts.CasesWithoutEstimatesByUser
{
    public class CasesWithoutEstimatesByUserChart : IPluggable, IChartWidget
    {
        public Guid Identifier { get; private set; }
        public string Title { get { return "Cases w/o Estimates by User"; } }
        public string SubTitle { get { return "Who needs to get yelled at?"; } }
        public ChartType ChartType { get { return ChartType.SparrowColumn; } }

        public ChartDataViewModel GetData(IEnumerable<CaseViewModel> visibleCases, IEnumerable<IntervalViewModel> intervals, IGenericDataSeriesFactory dataFactory)
        {
            var dataPoints = visibleCases.Where(c => c.EstimatedTime == 0)
                .GroupBy(c => c.AssignedTo)
                .Select(grp => new DataPointViewModel
                {
                    Category = grp.Key,
                    YValue = grp.Count()
                });

            var seriesCollection = new ObservableCollection<SeriesViewModel>();

            foreach (var dp in dataPoints)
            {
                var newSeries = new SeriesViewModel();
                newSeries.Name = dp.Category;
                newSeries.DataPoints.Add(dp);
                seriesCollection.Add(newSeries);
            }


            return new ChartDataViewModel
            {
                Title = Title,
                SubTitle = SubTitle,
                Series = seriesCollection,
                ChartType = ChartType.SparrowColumn
            };
        }
    }
}
