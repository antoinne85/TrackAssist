using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using Sparrow.Chart;
using TrackAssist.Shared.Charting;
using TrackAssist.Widgets.Charts.Sparrow;

namespace TrackAssist.Adapters
{
    public class SparrowChartsAdapter : IChartAdapter
    {
        public object Adapt(ChartDataViewModel chartVm)
        {
            var sparrowViewModel = new SparrowChartsViewModel
            {
                Title = chartVm.Title,
                SubTitle = chartVm.SubTitle,
            };

            foreach (var series in chartVm.Series)
            {
                var sparrowSeries = Adapt(series, chartVm.ChartType);
                sparrowSeries.Label = series.Name;
                sparrowViewModel.Series.Add(sparrowSeries);
                sparrowViewModel.XAxes.Add(sparrowSeries.XAxis);
                sparrowViewModel.YAxes.Add(sparrowSeries.YAxis);
            }

            return sparrowViewModel;
        }

        public FrameworkElement Create(ChartType chartType)
        {
            if (chartType == ChartType.SparrowLine)
            {
                return new LineChart();
            }

            return new LineChart();
        }

        private SeriesBase Adapt(SeriesViewModel series, ChartType chartType)
        {
            if (chartType == ChartType.SparrowLine)
            {
                return AdaptToLine(series);
            }
            
            if (chartType == ChartType.SparrowColumn)
            {
                return AdaptToColumn(series);
            }
            
            throw new ArgumentException("chartType", "No adaptation exists for the given ChartType.");
        }

        private SeriesBase AdaptToColumn(SeriesViewModel series)
        {
            var sparrowSeries = new ColumnSeries();
            sparrowSeries.XPath = "Category";
            sparrowSeries.YPath = "YValue";
            sparrowSeries.PointsSource = series.DataPoints;
            sparrowSeries.XAxis = new CategoryXAxis();
            sparrowSeries.YAxis = new LinearYAxis();
            return sparrowSeries;
        }

        private SeriesBase AdaptToLine(SeriesViewModel series)
        {
            var sparrowSeries = new LineSeries();
            sparrowSeries.XPath = "XValue";
            sparrowSeries.YPath = "YValue";
            sparrowSeries.PointsSource = series.DataPoints;
            sparrowSeries.XAxis = new LinearXAxis();
            sparrowSeries.YAxis = new LinearYAxis();
            return sparrowSeries;
        }
    }

    public class SparrowChartsViewModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public SeriesCollection Series { get; set; }
        public Axes XAxes { get; set; }
        public Axes YAxes { get; set; } 

        public SparrowChartsViewModel()
        {
            Title = string.Empty;
            SubTitle = string.Empty;
            Series = new SeriesCollection();
            XAxes = new Axes();
            YAxes = new Axes();
        }
    }

    public interface IChartAdapter
    {
        object Adapt(ChartDataViewModel chartVm);
        FrameworkElement Create(ChartType chartType);
    }
}
