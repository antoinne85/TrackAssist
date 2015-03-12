using System;

namespace TrackAssist.Contracts.Plugins
{
    public interface IFilterSource<in TTypeToFilter, in TFilterDataSource>
    {
        Func<TTypeToFilter, bool> GetFilterFunction(TFilterDataSource dataSource);
    }
}