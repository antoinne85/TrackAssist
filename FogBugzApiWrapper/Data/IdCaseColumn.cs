using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FogBugzApiWrapper.Data
{
    public enum IdCaseColumn
    {
        None = 0,
        [Description("ixDiscussionTopic")]
        [Display(Name = "Discussion Topic ID")]
        DiscussionTopicId = 1 << 1,
        [Description("ixBugEventLatestText")]
        [Display(Name = "Latest Bug Event ID w/ Comment")]
        LatestBugEventWithCommentId = 1 << 2,
        [Description("ixPersonOpenedBy")]
        [Display(Name = "Opened By User ID")]
        OpenedByUserId = 1 << 3,
        [Description("ixBugParent")]
        [Display(Name = "Parent Case Number")]
        ParentCaseNumber = 1 << 4,
        [Description("ixProject")]
        [Display(Name = "Project ID")]
        ProjectId = 1 << 5,
        [Description("ixArea")]
        [Display(Name = "Area ID")]
        AreaId = 1 << 6,
        [Description("ixGroup")]
        [Display(Name = "Group ID")]
        GroupId = 1 << 7,
        [Description("ixPersonAssignedTo")]
        [Display(Name = "Assigned To User ID")]
        AssignedToUserId = 1 << 8,
        [Description("ixPersonClosedBy")]
        [Display(Name = "Closed By User ID")]
        ClosedByUserId = 1 << 9,
        [Description("ixPersonLastEditedBy")]
        [Display(Name = "Last Edited By User ID")]
        LastEditedByUserId = 1 << 10,
        [Description("ixStatus")]
        [Display(Name = "StatusID")]
        StatusId = 1 << 11,
        [Description("ixPriority")]
        [Display(Name = "Priority ID")]
        PriorityId = 1 << 12,
        [Description("ixFixFor")]
        [Display(Name = "Milestone ID")]
        MilestoneId = 1 << 13,
        [Description("ixMailbox")]
        [Display(Name = "Mailbox ID")]
        MailboxId = 1 << 14,
        [Description("ixCategory")]
        [Display(Name = "Category ID")]
        CategoryId = 1 << 15,
        [Description("ixBugEventLatest")]
        [Display(Name = "Latest Bug Event ID")]
        LatestBugEventId = 1 << 16,
        [Description("ixBugEventLastView")]
        [Display(Name = "Latest Bug Event ID When Last Viewed")]
        LastBugEventIdForLastView = 1 << 17,
        [Description("ixBugOriginal")]
        [Display(Name = "Original Duplicate Case Number")]
        OriginalDuplicateCaseNumber = 1 << 18,
    }
}
