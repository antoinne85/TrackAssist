using System;
using System.Collections.Generic;
using System.Linq;
using TrackAssist.Contracts.Data;

namespace TrackAssist.Data.Factories
{
    public class BasicFilterFactory : IBasicFilterFactory
    {
        public Func<IEnumerable<TTypeToFilter>, IEnumerable<TTypeToFilter>> GetFilterFunction<TTypeToFilter, TDataSource>(TDataSource dataSource,
            Func<TDataSource, IEnumerable<object>> allowableValuesExpression,
            Func<TTypeToFilter, object> propertyOnFilterObject)
        {
            return (availableItems) =>
            {
                var allowableItems = allowableValuesExpression(dataSource);

                if (!allowableItems.Any())
                {
                    return availableItems;
                }

                return availableItems.Where(i => allowableItems.Contains(propertyOnFilterObject(i)));
            };
        }
    }
}