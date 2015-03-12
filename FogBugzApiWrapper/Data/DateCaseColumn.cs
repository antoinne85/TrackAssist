using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FogBugzApiWrapper.Data
{
    public enum DateCaseColumn
    {
        None = 0,
        [Description("dtFixFor")]
        [Display(Name = "Fix For Date")]
        MilestoneDate = 1 << 1,
        [Description("dtOpened")]
        [Display(Name = "Date Opened")]
        DateOpened = 1 << 2,
        [Description("dtResolved")]
        [Display(Name = "Date Resolved")]
        DateResolved = 1 << 3,
        [Description("dtClosed")]
        [Display(Name = "Date Closed")]
        DateClosed = 1 << 4,
        [Description("dtLastUpdated")]
        [Display(Name = "Date Last Updated")]
        DateLastUpdated = 1 << 5,
        [Description("dtDue")]
        [Display(Name = "Date Due")]
        DateDue = 1 << 6,
        [Description("dtLastView")]
        [Display(Name = "Date Last Viewed")]
        DateLastViewed = 1 << 7,
        [Description("dtLastOccurrence")]
        [Display(Name = "Date Scout Last Reported")]
        DateScoutLastReported = 1 << 8,
    }
}
