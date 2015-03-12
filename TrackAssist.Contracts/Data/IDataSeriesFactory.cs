using System;
using System.Collections.Generic;
using TrackAssist.Shared.Charting;
using TrackAssist.Shared.ViewModels;

namespace TrackAssist.Contracts.Data
{
    public interface IDataSeriesFactory<T>
    {
        SeriesViewModel Create(IEnumerable<T> input, string title, string description, Func<T, string> categorySelector, Func<T, double> valueSelector);
        
    }
}