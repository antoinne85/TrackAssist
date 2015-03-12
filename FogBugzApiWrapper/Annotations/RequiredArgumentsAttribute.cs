using System;
using FogBugzApiWrapper.Data;

namespace FogBugzApiWrapper.Annotations
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class RequiredArgumentsAttribute : AcceptableArgumentAttributeBase
    {
        public RequiredArgumentsAttribute(params Argument[] arguments) : base(arguments)
        {
            
        }
    }
}
