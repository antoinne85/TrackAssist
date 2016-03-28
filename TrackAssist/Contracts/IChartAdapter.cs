using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrackAssist.Shared.Charting;

namespace TrackAssist.Contracts
{
    public interface IChartAdapter
    {
        object Adapt(ChartDataViewModel chartVm);
        FrameworkElement Create(ChartType chartType);
    }
}
