using FogBugzApiWrapper.Contracts;

namespace FogBugzApiWrapper.Data
{
    public class GenericRequestArgument : IGenericRequestArgument
    {
        public Argument Argument { get; set; }
        public string Value { get; set; }
        public string RequestValue { get { return Value; } }
    }
}