using System;
using System.Collections.Generic;
using FogBugzApiWrapper.Contracts;
using FogBugzApiWrapper.Utilities;

namespace FogBugzApiWrapper.Data
{
    public class GenericFogBugzRequestUriBuilder
    {
        public string Generate(string apiEndopint, GenericFogBugzRequest genericRequest)
        {
            var arguments = GenerateArguments(genericRequest);
            var commandName = GetUriName(genericRequest.Command);
            return string.Format("{0}?cmd={1}&{2}", apiEndopint, commandName, arguments);
        }

        public string GenerateArguments(GenericFogBugzRequest genericRequest)
        {
            var argumentParts = new List<string>();
            foreach (var argument in genericRequest.Arguments)
            {
                argumentParts.Add(GenerateArgument(argument));
            }

            return string.Join("&", argumentParts);
        }

        private string GenerateArgument(IGenericRequestArgument argument)
        {
            var argumentName = GetUriName(argument.Argument);
            return string.Format("{0}={1}", argumentName, argument.RequestValue);
        }

        private string GetUriName<T>(T command) where T : struct, IConvertible
        {
            return EnumUtils.GetUriName(command);
        }
    }
}