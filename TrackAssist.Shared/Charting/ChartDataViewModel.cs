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
    }
}
