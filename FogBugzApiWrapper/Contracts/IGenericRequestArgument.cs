using FogBugzApiWrapper.Data;

namespace FogBugzApiWrapper.Contracts
{
    public interface IGenericRequestArgument
    {
        Argument Argument { get; }
        string Value { get; }
        string RequestValue { get; }
    }
}