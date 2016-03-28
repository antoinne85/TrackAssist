using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TrackAssist.Contracts;
using TrackAssist.Contracts.Data;
using TrackAssist.Contracts.Enums;
using TrackAssist.Contracts.Plugins;
using TrackAssist.Data.Factories;
using TrackAssist.Shared.Charting;
using TrackAssist.Shared.ViewModels;
using TrackAssist.ViewModels;

namespace TrackAssist.Widgets.Charts
{
    public class TimesheetChart : IChartWidget, IPluggable
    {
        public string Title { get { return "Time Entry by User"; } }
        public string SubTitle { get { return "Who's putting in their hours?"; } }
        public ChartType ChartType { get { return ChartType.CategoricalColumn; } }
        public ChartDataViewModel GetData(IEnumerable<CaseViewModel> visibleCases, IEnumerable<IntervalViewModel> intervals, IGenericDataSeriesFactory dataFactory)
        {
            var groupedByDate = intervals.GroupBy(i => i.StartDate.Date);
            var users = intervals.Select(i => i.Username).Distinct();
            var allSeries = new List<SeriesViewModel>();
            foreach (var group in groupedByDate.OrderBy(d => d.Key))
            {
                var series = new SeriesViewModel();
                series.Name = group.Key.ToString("M");

                var groupedByUser = group.GroupBy(i => i.Username);
                foreach (var intervalSet in groupedByUser)
                {
                    var dataPoint = new DataPointViewModel();
                    dataPoint.Category = intervalSet.Key;
                    dataPoint.YValue = intervalSet.Sum(i => i.Length);
                    series.DataPoints.Add(dataPoint);
                }

                foreach (var user in users.Except(groupedByUser.Select(grp => grp.Key)))
                {
                    var dataPoint = new DataPointViewModel();
                    dataPoint.Category = user;
                    dataPoint.YValue = 0;
                    series.DataPoints.Add(dataPoint);
                }

                allSeries.Add(series);
            }

            return new ChartDataViewModel
            {
                Series = new ObservableCollection<SeriesViewModel>(allSeries),
                Title = Title,
                SubTitle = SubTitle,
                ChartType = ChartType.CategoricalColumn
            };
        }

        private SeriesViewModel GenerateSeries(DateTime startDate, DateTime endDate, IEnumerable<IntervalViewModel> intervals)
        {
            var series = new SeriesViewModel();

            while (startDate <= endDate)
            {
                var time = intervals.Where(i => i.StartDate.Date == startDate).Sum(i => i.Length);
                series.DataPoints.Add(new DataPointViewModel
                {
                    Category = startDate.ToString("M"),
                    YValue = time
                });
            }

            return series;
        }

        public Guid Identifier { get; private set; }
    }
}
