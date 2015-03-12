using System;
using System.Linq;
using FogBugzApiWrapper.Contracts;
using FogBugzApiWrapper.Utilities;

namespace FogBugzApiWrapper.Data
{
    public class GenericRequestFlagArgument<T> : IGenericRequestArgument where T : struct, IConvertible
    {
        public Argument Argument { get; set; }

        public string Value
        {
            get { return EnumUtils.GetUriValues(FlagValue); }
        }

        public string RequestValue { get { return Value; } }

        public T FlagValue { get; set; }
    }

    public class CaseColumnArgument : IGenericRequestArgument
    {
        public Argument Argument
        {
            get
            {
                return Argument.ColumnsToReturn;
            }
        }

        public string Value
        {
            get
            {
                var allArgs = new[]
                {
                    EnumUtils.GetUriValues(BasicColumns),
                    EnumUtils.GetUriValues(IdColumns),
                    EnumUtils.GetUriValues(DateColumns),
                    EnumUtils.GetUriValues(ScoutColumns)
                };
                return string.Join(",", allArgs.Where(a => !string.IsNullOrWhiteSpace(a)));
            } 
        }

        public string RequestValue { get { return Value; } }

        public CaseColumn BasicColumns { get; set; }
        public IdCaseColumn IdColumns { get; set; }
        public DateCaseColumn DateColumns { get; set; }
        public ScoutCaseColumn ScoutColumns { get; set; }
    }
}