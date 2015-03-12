using System;
using System.Collections.Generic;
using FogBugzApiWrapper.RequestObjects;
using TrackAssist.Contracts;
using TrackAssist.Contracts.Data;
using TrackAssist.Shared.Charting;
using TrackAssist.Shared.ViewModels;
using TrackAssist.ViewModels;
using TrackAssist.Widgets.Charts;

namespace TrackAssist.Data.Factories
{
    public class DataPointFactory : IDataPointFactory
    {
        public DataPointViewModel Create<T>(T input, Func<T,string> categorySelector, Func<T,double> valueSelector)
        {
            return new DataPointViewModel
            {
                Category = categorySelector(input),
                YValue = valueSelector(input)
            };
        }
    }

    public class CaseGenericDataSeriesFactory : GenericDataSeriesFactory
    {
        public CaseGenericDataSeriesFactory(IDataPointFactory dataPointFactory) : base(dataPointFactory)
        {
        }

        public SeriesViewModel Create(IEnumerable<Case> input, string title, string description, Func<Case, string> categorySelector, Func<Case, double> valueSelector)
        {
            return base.Create(input, title, description, categorySelector, valueSelector);
        }

    }
}
