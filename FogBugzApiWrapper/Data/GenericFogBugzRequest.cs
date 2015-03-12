using System.Collections.Generic;
using System.Linq;
using FogBugzApiWrapper.Contracts;

namespace FogBugzApiWrapper.Data
{
    public class GenericFogBugzRequest : IGenericFogBugzRequest
    {
        public virtual Command Command { get; set; }
        public List<IGenericRequestArgument> Arguments { get; set; }

        public GenericFogBugzRequest()
        {
            Arguments = new List<IGenericRequestArgument>();
        }

        public bool HasArgument(Argument argument)
        {
            return Arguments.Any(a => a.Argument == argument);
        }
    }
}