using System.Collections.ObjectModel;

namespace TrackAssist.Shared.Charting
{
    public class SeriesViewModel
    {
        public string Name { get; set; }
        public ObservableCollection<DataPointViewModel> DataPoints { get; set; }

        public SeriesViewModel()
        {
            DataPoints = new ObservableCollection<DataPointViewModel>();
        }
    }
}