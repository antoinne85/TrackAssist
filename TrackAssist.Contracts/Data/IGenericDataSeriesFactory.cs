using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TrackAssist.Contracts.Enums;
using TrackAssist.Shared.Charting;
using TrackAssist.Shared.ViewModels;

namespace TrackAssist.Contracts.Data
{
    public interface IGenericDataSeriesFactory
    {
        SeriesViewModel Create<T>(IEnumerable<T> input, string title, string description, Func<T, string> categorySelector, Func<T, double> valueSelector);
        SeriesViewModel Create<T>(IEnumerable<T> input, Expression<Func<T, string>> categoryProperty, Expression<Func<T, double>> valueProperty);
        SeriesViewModel Create<T>(IEnumerable<T> input, Expression<Func<T, string>> categoryProperty, Expression<Func<T, double>> valueProperty, ValueAggregationMode aggregationMode);
        string GenerateTitleFromParameters<T>(Expression<Func<T, string>> categoryProperty, Expression<Func<T, double>> valueProperty);

        List<SeriesViewModel> CreateGrouped<T>(IEnumerable<T> input, Expression<Func<T, string>> groupingProperty,
            List<GroupedSeriesValueConfig<T>> valueConfigs);

        List<SeriesViewModel> CreateGrouped<T>(IEnumerable<T> input, Expression<Func<T, string>> groupingProperty, List<GroupedSeriesValueConfig<T>> valueConfigs, ValueAggregationMode aggregationMode);
    }
}