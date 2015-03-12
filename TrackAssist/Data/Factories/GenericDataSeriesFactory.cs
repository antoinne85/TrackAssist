using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using FogBugzApiWrapper.Utilities;
using TrackAssist.Contracts;
using TrackAssist.Contracts.Data;
using TrackAssist.Contracts.Enums;
using TrackAssist.Shared.Charting;
using TrackAssist.Shared.ViewModels;
using TrackAssist.Utilities;
using TrackAssist.ViewModels;
using TrackAssist.Widgets.Charts;

namespace TrackAssist.Data.Factories
{
    public class GenericDataSeriesFactory : IGenericDataSeriesFactory
    {
        private readonly IDataPointFactory _dataPointFactory;

        public GenericDataSeriesFactory(IDataPointFactory dataPointFactory)
        {
            if (dataPointFactory == null)
            {
                throw new ArgumentNullException("dataPointFactory");
            }
            _dataPointFactory = dataPointFactory;
        }

        public SeriesViewModel Create<T>(IEnumerable<T> input, string title, string description, Func<T, string> categorySelector, Func<T, double> valueSelector)
        {
            var series = new SeriesViewModel
            {
                Name = title,
                DataPoints = new ObservableCollection<DataPointViewModel>()
            };

            foreach (var item in input)
            {
                series.DataPoints.Add(_dataPointFactory.Create(item, categorySelector, valueSelector));
            }

            return series;
        }

        public SeriesViewModel Create<T>(IEnumerable<T> input, Expression<Func<T, string>> categoryProperty, Expression<Func<T, double>> valueProperty)
        {
            return Create(input, categoryProperty, valueProperty, ValueAggregationMode.Sum);
        }

        public SeriesViewModel Create<T>(IEnumerable<T> input, Expression<Func<T, string>> categoryProperty, Expression<Func<T, double>> valueProperty, ValueAggregationMode aggregationMode)
        {
            var series = new SeriesViewModel
            {
                DataPoints = new ObservableCollection<DataPointViewModel>()
            };

            var categorySelector = categoryProperty.Compile();
            var valueSelector = valueProperty.Compile();

            var rawDataPoints = new List<DataPointViewModel>();
            foreach (var item in input)
            {
                rawDataPoints.Add(_dataPointFactory.Create(item, categorySelector, valueSelector));
            }

            var groupedDataPoints = rawDataPoints.GroupBy(dp => dp.Category);
            var aggregatedDataPoints = AggregateValues(groupedDataPoints, aggregationMode);
            series.DataPoints = new ObservableCollection<DataPointViewModel>(aggregatedDataPoints);
            series.Name = GenerateTitleFromParameters(categoryProperty, valueProperty);

            return series;
        }

        private List<DataPointViewModel> AggregateValues(IEnumerable<IGrouping<string, DataPointViewModel>> groupedDataPoints, ValueAggregationMode aggregationMode)
        {
            var dataPoints = new List<DataPointViewModel>();
            if (aggregationMode == ValueAggregationMode.Sum || aggregationMode == ValueAggregationMode.Average)
            {
                foreach (var group in groupedDataPoints)
                {
                    dataPoints.Add(new DataPointViewModel
                    {
                        Category = group.Key,
                        YValue = AggregateValues(group, aggregationMode)
                    });
                }
            }
            else if (aggregationMode == ValueAggregationMode.PercentOfWhole)
            {
                dataPoints = AggregateValues(groupedDataPoints, ValueAggregationMode.Sum);
                var sumOfAllValues = dataPoints.Sum(dp => dp.YValue);

                foreach (var dataPoint in dataPoints)
                {
                    dataPoint.YValue = dataPoint.YValue/sumOfAllValues;
                }
            }

            return dataPoints;
        }

        private double AggregateValues(IEnumerable<DataPointViewModel> dataPoints, ValueAggregationMode mode)
        {
            var values = dataPoints.Select(dp => dp.YValue);
            if (mode == ValueAggregationMode.Sum)
            {
                return values.Sum();
            }

            if (mode == ValueAggregationMode.Average)
            {
                return values.Average();
            }

            throw new ArgumentException("mode", "Unrecognized ValueAggregationMode.");
        }

        public string GenerateTitleFromParameters<T>(Expression<Func<T, string>> categoryProperty, Expression<Func<T, double>> valueProperty)
        {
            var categoryExpression = LambdaUtils.GetMemberInfo(categoryProperty);
            var valueExpression = LambdaUtils.GetMemberInfo(valueProperty);
            

            var categoryName = EnumUtils.GetDisplayNameAttributeValue(categoryExpression.Member);
            var valueName = EnumUtils.GetDisplayNameAttributeValue(valueExpression.Member);

            return string.Format("{0} by {1}", valueName, categoryName);
        }

        public List<SeriesViewModel> CreateGrouped<T>(IEnumerable<T> input, Expression<Func<T, string>> groupingProperty,
            List<GroupedSeriesValueConfig<T>> valueConfigs)
        {
            return CreateGrouped(input, groupingProperty, valueConfigs, ValueAggregationMode.Sum);
        }

        public List<SeriesViewModel> CreateGrouped<T>(IEnumerable<T> input, Expression<Func<T, string>> groupingProperty, List<GroupedSeriesValueConfig<T>> valueConfigs, ValueAggregationMode aggregationMode)
        {
            foreach (var config in valueConfigs)
            {
                config.CompiledValueSelector = config.ValueSelector.Compile();
            }

            var categorySelector = groupingProperty.Compile();
            var groupings = input.GroupBy(categorySelector);

            var allSeries = new List<SeriesViewModel>();
            foreach (var grouping in groupings)
            {
                var series = new SeriesViewModel
                {
                    DataPoints = new ObservableCollection<DataPointViewModel>()
                };

                foreach (var config in valueConfigs)
                {
                    var tempSeries = Create(grouping, groupingProperty, config.ValueSelector, aggregationMode);
                    foreach (var dataPoint in tempSeries.DataPoints)
                    {
                        series.DataPoints.Add(dataPoint);
                        dataPoint.Category = config.Name;
                    }
                }

                allSeries.Add(series);
                series.Name = grouping.Key;
            }
            return allSeries;
        }
    }
}