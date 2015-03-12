using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FogBugzApiWrapper.Data
{
    public enum ScoutCaseColumn
    {
        None = 0,
        [Description("sScoutDescription")]
        [Display(Name = "Scout Description")]
        ScoutDescription = 1 << 1,
        [Description("sScoutMessage")]
        [Display(Name = "Scout Message")]
        ScoutMessage = 1 << 2,
        [Description("fScoutStopReporting")]
        [Display(Name = "Scout Is Reporting")]
        ScoutIsReporting = 1 << 3,
    }
}
