using System;
using System.Linq.Expressions;

namespace TrackAssist.Shared.Charting
{
    public class GroupedSeriesValueConfig<T>
    {
        public Expression<Func<T, double>> ValueSelector { get; set; }
        public Func<T, double> CompiledValueSelector { get; set; } 
        public string Name { get; set; }
    }
}