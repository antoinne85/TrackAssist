using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FogBugzApiWrapper.Data
{
    [Flags]
    public enum CaseColumn
    {
        None = 0,
        [Description("ixBug")]
        [Display(Name = "Number")]
        Number = 1 << 0,
        [Description("sTitle")]
        [Display(Name = "Title")]
        Title = 1 << 1,
        [Description("fOpen")]
        [Display(Name = "Open")]
        IsOpen = 1 << 2,
        [Description("sPriority")]
        [Display(Name = "Priority")]
        Priority = 1 << 3,
        [Description("ixBugChildren")]
        [Display(Name = "Child Case Numbers")]
        ChildCaseNumbers = 1 << 4,
        [Description("tags")]
        [Display(Name = "Tags")]
        Tags = 1 << 5,
        [Description("sOriginalTitle")]
        [Display(Name = "Original Title")]
        OriginalTitle = 1 << 6,
        [Description("sLatestTextSummary")]
        [Display(Name = "Latest Text Summary")]
        LatestTextSummary = 1 << 7,
        [Description("sProject")]
        [Display(Name = "Project Name")]
        ProjectName = 1 << 8,
        [Description("sArea")]
        [Display(Name = "Area Name")]
        AreaName = 1 << 9,
        [Description("sPersonAssignedTo")]
        [Display(Name = "Assigned To User Name")]
        AssignedToUserName = 1 << 10,
        [Description("sEmailAssignedTo")]
        [Display(Name = "Email Assigned To")]
        EmailAssignedTo = 1 << 11,
        [Description("ixBugDuplicates")]
        [Display(Name = "Duplicate Case Numbers")]
        DuplicateCaseNumbers = 1 << 12,
        [Description("sStatus")]
        [Display(Name = "Status")]
        StatusName = 1 << 13,
        [Description("sFixFor")]
        [Display(Name = "Milestone Name")]
        MilestoneName = 1 << 14,
        [Description("hrsOrigEst")]
        [Display(Name = "Original Estimate (hrs)")]
        OriginalEstimateInHours = 1 << 15,
        [Description("hrsCurrEst")]
        [Display(Name = "Current Estimate (hrs)")]
        CurrentEstimateInHours = 1 << 16,
        [Description("hrsElapsed")]
        [Display(Name = "Elapsed (hrs)")]
        ElapsedHours = 1 << 17,
        [Description("sCustomerEmail")]
        [Display(Name = "Customer Email")]
        CustomerEmail = 1 << 18,
        [Description("sCategory")]
        [Display(Name = "Category Name")]
        CategoryName = 1 << 19,
        [Description("sTicket")]
        [Display(Name = "Customer View Ticket")]
        CustomerViewTicket = 1 << 20,
        [Description("sReleaseNotes")]
        [Display(Name = "Release Notes")]
        ReleaseNotes = 1 << 21,
        [Description("ixRelatedBugs")]
        [Display(Name = "Related Case Numbers")]
        RelatedCaseNumbers = 1 << 22,
        [Description("fSubscribed")]
        [Display(Name = "Subscribed")]
        Subscribed = 1 << 23,
        [Description("fReplied")]
        [Display(Name = "Replied")]
        IsRepliedTo = 1 << 24,
        [Description("fForwarded")]
        [Display(Name = "Forwarded")]
        IsForwarded = 1 << 25,
        [Description("c")]
        [Display(Name = "Number of Occurrences")]
        NumberOfOccurrences = 1 << 26,
        [Description("sVersion")]
        [Display(Name = "Version")]
        Version = 1 << 27,
        [Description("sComputer")]
        [Display(Name = "Computer")]
        Computer = 1 << 28,
        [Description("events")]
        [Display(Name = "Events")]
        Events = 1 << 29


    }
}
