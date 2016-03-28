using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PostSharp.Patterns.Model;
using TrackAssist.Contracts.Data;
using TrackAssist.Shared.Charting;
using TrackAssist.Shared.ViewModels;
using TrackAssist.Adapters;

namespace TrackAssist.Widgets.Charts
{
    [NotifyPropertyChanged]
    public class ChartConnection
    {
        public Func<IEnumerable<CaseViewModel>, IEnumerable<IntervalViewModel>, IGenericDataSeriesFactory, ChartDataViewModel> DataGenerationFunction
        { get; set; }

        public object ViewModel { get; set; }

        public ChartConnection()
        {
          ViewModel = new SyncFusionChartViewModel();
        }
    }
}