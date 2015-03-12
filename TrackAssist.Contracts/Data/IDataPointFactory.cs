using System;
using TrackAssist.Shared.Charting;
using TrackAssist.Shared.ViewModels;

namespace TrackAssist.Contracts.Data
{
    public interface IDataPointFactory
    {
        DataPointViewModel Create<T>(T input, Func<T,string> categorySelector, Func<T,double> valueSelector);
    }
}
