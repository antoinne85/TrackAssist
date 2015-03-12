using System;
using System.Collections.Generic;
using TrackAssist.Contracts.Data;
using TrackAssist.Shared.ViewModels;

namespace TrackAssist.Contracts.Plugins
{
    public interface IRegisterableFilterSource
    {
        Func<IEnumerable<CaseViewModel>, IEnumerable<CaseViewModel>> GetCaseFilterFunction(IBasicFilterFactory filterFactory);
        Func<IEnumerable<IntervalViewModel>, IEnumerable<IntervalViewModel>> GetIntervalFilterFunction(IBasicFilterFactory filterFactory);
    }
}