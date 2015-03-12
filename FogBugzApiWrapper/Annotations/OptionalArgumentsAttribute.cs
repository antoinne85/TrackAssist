using FogBugzApiWrapper.Data;

namespace FogBugzApiWrapper.Annotations
{
    public class OptionalArgumentsAttribute : AcceptableArgumentAttributeBase
    {
        public OptionalArgumentsAttribute(params Argument[] arguments) : base(arguments)
        {
            
        }
    }
}
