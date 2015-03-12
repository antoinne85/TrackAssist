using System.Collections.Generic;
using TrackAssist.Contracts.Data;
using TrackAssist.Contracts.Enums;
using TrackAssist.Shared.Charting;
using TrackAssist.Shared.ViewModels;

namespace TrackAssist.Contracts.Plugins
{
    public interface IChartWidget
    {
        ChartType ChartType { get; }
        ChartDataViewModel GetData(IEnumerable<CaseViewModel> visibleCases, IEnumerable<IntervalViewModel> intervals, IGenericDataSeriesFactory dataFactory);
    }
}