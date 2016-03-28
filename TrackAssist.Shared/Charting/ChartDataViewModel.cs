using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAssist.Shared.Charting
{
  public class ChartDataViewModel
  {
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public ObservableCollection<SeriesViewModel> Series { get; set; }
    public ChartType ChartType { get; set; }

    public ChartDataViewModel()
    {
      Title = "Chart Title";
      SubTitle = "Chart Subtitle";
      ChartType = Charting.ChartType.Line;
      Series = new ObservableCollection<SeriesViewModel>
      {
        new SeriesViewModel
        {
          Name = "Sample Series",
          DataPoints = new ObservableCollection<DataPointViewModel>
          {
            new DataPointViewModel
            {
              Category = "Sample Category",
              XValue = 1,
              YValue = 1
            },
            new DataPointViewModel
            {
              Category = "Sample Category",
              XValue = 2,
              YValue = 2
            },
            new DataPointViewModel
            {
              Category = "Sample Category",
              XValue = 3,
              YValue = 3
            },
            new DataPointViewModel
            {
              Category = "Sample Category",
              XValue = 4,
              YValue = 4
            },
            new DataPointViewModel
            {
              Category = "Sample Category",
              XValue = 5,
              YValue = 5
            },
          }
        }
      };
    }
  }
}
