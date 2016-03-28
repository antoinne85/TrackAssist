using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrackAssist.Shared.Charting;
using TrackAssist.Widgets.Charts.SyncFusion;
using PostSharp.Patterns.Model;
using Syncfusion.UI.Xaml.Charts;

namespace TrackAssist.Adapters
{
    public class SyncFusionChartsAdapter : IChartAdapter
    {

        public object Adapt(ChartDataViewModel chartVm)
        {
          var vm = new SyncFusionChartViewModel
          {
            Title = chartVm.Title,
          };

          foreach (var series in chartVm.Series)
          {
            //if (chartVm.ChartType == ChartType.SparrowLine || chartVm.ChartType == ChartType.Line)
            //{
              
            //}
            var convertedSeries = new ColumnSeries{
                ItemsSource = series.DataPoints,
                XBindingPath = "XValue",
                YBindingPath = "YValue",
                Label = series.Name
                };

            if (chartVm.ChartType == ChartType.CategoricalColumn)
            {
              convertedSeries.XBindingPath = "Category";
            }

            vm.Series.Add(convertedSeries);
          }

          return vm;
        }

        public FrameworkElement Create(ChartType chartType)
        {
          return new LineChart();
        }

        private object Adapt(SeriesViewModel series, ChartType chartType)
        {
            return new LineChart();

            throw new ArgumentException("chartType", "No adaptation exists for the given ChartType.");
        }

        private object AdaptToColumn(SeriesViewModel series)
        {
            return new object();
        }

        private object AdaptToLine(SeriesViewModel series)
        {
            return new object();
        }
    }

    [NotifyPropertyChanged]
    public class SyncFusionChartViewModel
    {
        public string Title { get; set; }
        public ChartSeriesCollection Series { get; set; }

      public SyncFusionChartViewModel()
      {
        Title = "No Title";
        Series = new ChartSeriesCollection();
      }
      
    }

    public class SyncFusionChartPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
