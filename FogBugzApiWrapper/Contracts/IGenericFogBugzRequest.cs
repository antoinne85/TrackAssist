using System.Collections.Generic;
using FogBugzApiWrapper.Data;

namespace FogBugzApiWrapper.Contracts
{
    public interface IGenericFogBugzRequest
    {
        Command Command { get; set; }
        List<IGenericRequestArgument> Arguments { get; set; }
        bool HasArgument(Argument argument);
    }
}