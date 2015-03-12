using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FogBugzApiWrapper.Contracts;
using FogBugzApiWrapper.Data;
using FogBugzApiWrapper.Utilities;

namespace FogBugzApiWrapper.Requests.Cases
{
    public class CaseApi
    {
         
    }

    public class ListCasesRequest : GenericFogBugzRequest
    {
        public override Command Command { get{ return Command.Search;} }
        public List<IGenericRequestArgument> Arguments { get; set; }

        public ListCasesRequest()
        {
            Arguments = new List<IGenericRequestArgument>();
        }

        public bool HasArgument(Argument argument)
        {
            return Arguments.Any(a => a.Argument == argument);
        }
    }

    public class QueryRequestArgument : IGenericRequestArgument
    {
        public Argument Argument { get { return Argument.Query; } }
        public List<IQueryFilter> QueryFilters { get; set; }

        public void AddFilter(IQueryFilter queryFilter)
        {
            QueryFilters.Add(queryFilter);
        }

        public string Value { get; set; }
        public string RequestValue
        {
            get
            {
                var filteredPart = BuildRequestValue(QueryFilters);
                return string.Format("{0} {1}", filteredPart, Value);
            }
        }

        private string BuildRequestValue(IEnumerable<IQueryFilter> filters)
        {
            var queryParts = filters.Select(BuildRequestValue);
            return string.Join(" ", queryParts);
        }

        private string BuildRequestValue(IQueryFilter queryFilter)
        {
            var axis = EnumUtils.GetUriName(queryFilter.Argument);
            var negation = queryFilter.Negate ? "-" : string.Empty;
            return string.Format(@"{0}{1}:""{2}""", negation, axis, queryFilter.Value);
        }
    }

    public class DateQueryFilter : IQueryFilter
    {
        public QueryArgument Argument { get; set; }

        public string Value
        {
            get { return BuildValue(); }
        }

        private string BuildValue()
        {
            if (Preset.HasValue)
            {
                return EnumUtils.GetUriName(Preset.Value);
            }

            var start = string.Empty;
            var connector = string.Empty;
            var end = string.Empty;
            if (StartDate.HasValue)
            {
                start = StartDate.Value.ToString("MM/dd/yyyy");
            }

            if (EndDate.HasValue)
            {
                end = EndDate.Value.ToString("MM/dd/yyyy");
            }

            if (StartDate.HasValue && EndDate.HasValue)
            {
                connector = "..";
            }

            return string.Format("{0}{1}{2}", start, connector, end);
        }

        public bool Negate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateQueryArgumentPreset? Preset { get; set; }
    }

    public enum DateQueryArgumentPreset
    {
        [Description("today")]
        [Display(Name = "Today")]
        Today,
        [Description("last Sunday")]
        [Display(Name = "Last Sunday")]
        LastSunday,
        [Description("last Monday")]
        [Display(Name = "Last Monday")]
        LastMonday,
        [Description("last Tuesday")]
        [Display(Name = "Last Tuesday")]
        LastTuesday,
        [Description("last Wednesday")]
        [Display(Name = "Last Wednesday")]
        LastWednesday,
        [Description("last Thursday")]
        [Display(Name = "Last Thursday")]
        LastThursday,
        [Description("last Friday")]
        [Display(Name = "Last Friday")]
        LastFriday,
        [Description("last Saturday")]
        [Display(Name = "Last Saturday")]
        LastSaturday,
        [Description("last month")]
        [Display(Name = "Last Month")]
        LastMonth,
        [Description("this week")]
        [Display(Name = "ThisWeek")]
        ThisWeek,
        [Description("yesterday")]
        [Display(Name = "Yesterday")]
        Yesterday,
        [Description("tomorrow")]
        [Display(Name = "Tomorrow")]
        Tomorrow,
        [Description("next week")]
        [Display(Name = "NextWeek")]
        NextWeek
    }

    public class QueryFilter : IQueryFilter
    {
        public QueryArgument Argument { get; set; }
        public string Value { get; set; }
        public bool Negate { get; set; }
    }

    public interface IQueryFilter
    {
        QueryArgument Argument { get; }
        string Value { get; }
        bool Negate { get; }
    }
}
