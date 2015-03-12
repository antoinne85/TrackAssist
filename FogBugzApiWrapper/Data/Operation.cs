using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FogBugzApiWrapper.Data
{
    public enum Operation
    {
        //TODO: Some of these may no longer be valid.
        [Description("edit")]
        [Display(Name = "Edit")]
        Edit,
        [Description("assign")]
        [Display(Name = "Assign")]
        Assign,
        [Description("resolve")]
        [Display(Name = "Resolve")]
        Resolve,
        [Description("reactivate")]
        [Display(Name = "Reactivate")]
        Reactivate,
        [Description("close")]
        [Display(Name = "Close")]
        Close,
        [Description("reopen")]
        [Display(Name = "Reopen")]
        Reopen,
        [Description("reply")]
        [Display(Name = "Reply")]
        Reply,
        [Description("forward")]
        [Display(Name = "Forward")]
        Forward,
        [Description("email")]
        [Display(Name = "Email")]
        Email,
        [Description("move")]
        [Display(Name = "Move")]
        Move,
        [Description("spam")]
        [Display(Name = "Spam")]
        Spam,
        [Description("remind")]
        [Display(Name = "Remind")]
        Remind
    }
}