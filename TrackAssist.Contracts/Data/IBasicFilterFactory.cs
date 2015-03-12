using System;
using System.Collections.Generic;

namespace TrackAssist.Contracts.Data
{
    public interface IBasicFilterFactory
    {
        Func<IEnumerable<TTypeToFilter>, IEnumerable<TTypeToFilter>> GetFilterFunction<TTypeToFilter, TDataSource>(TDataSource dataSource,
            Func<TDataSource, IEnumerable<object>> allowableValuesExpression,
            Func<TTypeToFilter, object> propertyOnFilterObject);
    }
}