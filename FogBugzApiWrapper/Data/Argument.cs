using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FogBugzApiWrapper.Data
{
    public enum Argument
    {
        [Description("token")]
        [Display(Name = "Login Token")]
        LoginToken,
        [Description("email")]
        [Display(Name = "Email")]
        Email,
        [Description("password")]
        [Display(Name = "Password")]
        Password,
        [Description("q")]
        [Display(Name = "Query")]
        Query,
        [Description("cols")]
        [Display(Name = "Columns To Return")]
        ColumnsToReturn,
        [Description("max")]
        [Display(Name = "Maximum Result Count")]
        MaxResults,
        [Description("ixBug")]
        [Display(Name = "Case Number")]
        CaseNumber,
        [Description("ixBugParent")]
        [Display(Name = "Parent Case Number")]
        ParentCaseNumber,
        [Description("ixBugEvent")]
        [Display(Name = "Case Event ID")]
        CaseEventId,
        [Description("tags")]
        [Display(Name = "Tags Read")]
        TagsRead,
        [Description("sTags")]
        [Display(Name = "Tags Write")]
        TagsWrite,
        [Description("sTitle")]
        [Display(Name = "Title")]
        Title,
        [Description("ixProject")]
        [Display(Name = "Project ID")]
        ProjectId,
        [Description("sProject")]
        [Display(Name = "Project Name")]
        ProjectName,
        [Description("ixArea")]
        [Display(Name = "Area ID")]
        AreaId,
        [Description("sArea")]
        [Display(Name = "Area Name")]
        AreaName,
        [Description("ixFixFor")]
        [Display(Name = "Milestone ID")]
        MilestoneId,
        [Description("sFixFor")]
        [Display(Name = "Milestone Name")]
        MilestoneName,
        [Description("ixCategory")]
        [Display(Name = "Category ID")]
        CategoryId,
        [Description("sCategory")]
        [Display(Name = "Category Name")]
        CategoryName,
        [Description("ixPersonAssignedTo")]
        [Display(Name = "Assign To User ID")]
        AssignedToUserId,
        [Description("sPersonAssignedTo")]
        [Display(Name = "Assigned To User Name")]
        AssignedToUserName,
        [Description("ixPriority")]
        [Display(Name = "Priority ID")]
        PriorityId,
        [Description("sPriority")]
        [Display(Name = "Priority Name")]
        PriorityName,
        [Description("dtDue")]
        [Display(Name = "Date Due")]
        DateDue,
        [Description("hrsCurrEst")]
        [Display(Name = "Hours Current Estimate")]
        HoursCurrentEstimate,
        [Description("fWrite")]
        [Display(Name = "Show Only Editable")]
        ShowOnlyEditable,
        [Description("fIncludeDeleted")]
        [Display(Name = "Include Deleted")]
        IncludeDeleted,
        [Description("fIncludeActive")]
        [Display(Name = "Include Active")]
        IncludeActive,
        [Description("fIncludeNormal")]
        [Display(Name = "Include Normal")]
        IncludeNormal,
        [Description("fIncludeCommunity")]
        [Display(Name = "Include Community")]
        IncludeCommunity,
        [Description("fIncludeVirtual")]
        [Display(Name = "Include Virtual")]
        IncludeVirtual,
        [Description("fResolved")]
        [Display(Name = "Is Resolved")]
        IsResolved,
        [Description("fIncludeReallyDeleted")]
        [Display(Name = "Include Really Deleted")]
        IncludeReallyDeleted,
        [Description("fGlobalOnly")]
        [Display(Name = "Global Only")]
        GlobalOnly,
        [Description("ixPersonPrimaryContact")]
        [Display(Name = "Primary Contact ID")]
        PrimaryContactId,
        [Description("fAllowPublicSubmit")]
        [Display(Name = "Allow Public Submit")]
        AllowPublicSubmit,
        [Description("fInbox")]
        [Display(Name = "Use Inbox")]
        UseInbox,
        [Description("sFullname")]
        [Display(Name = "Full Name")]
        FullName,
        [Description("nType")]
        [Display(Name = "User Type")]
        UserType,
        [Description("fActive")]
        [Display(Name = "Is Active")]
        IsActive,
        [Description("sLocale")]
        [Display(Name = "Locale")]
        LocaleName,
        [Description("sLanguage")]
        [Display(Name = "Language")]
        Language,
        [Description("sTimeZoneKey")]
        [Display(Name = "Time Zone Key")]
        TimeZoneKey,
        [Description("sSnippetKey")]
        [Display(Name = "Snippet Key")]
        SnippetKey,
        [Description("fNotify")]
        [Display(Name = "Notify")]
        Notify,
        [Description("sPhone")]
        [Display(Name = "Phone Number")]
        PhoneNumber,
        [Description("sHomepage")]
        [Display(Name = "Homepage")]
        Homepage,
        [Description("fDeleted")]
        [Display(Name = "Deleted")]
        Deleted,
        [Description("dtRelease")]
        [Display(Name = "Release Date")]
        ReleaseDate,
        [Description("dtStart")]
        [Display(Name = "Start Date")]
        StartDate,
        [Description("sStartNote")]
        [Display(Name = "Start Note")]
        StartNote,
        [Description("fAssignable")]
        [Display(Name = "Assignable")]
        Assignable,
        [Description("ixPerson")]
        [Display(Name = "User ID")]
        UserId,
        [Description("ixStatus")]
        [Display(Name = "Status ID")]
        StatusId,
        [Description("sStatus")]
        [Display(Name = "Status Name")]
        StatusName,
        [Description("ixMailbox")]
        [Display(Name = "Mailbox ID")]
        MailboxId,
        [Description("ixTemplate")]
        [Display(Name = "Template ID")]
        TemplateId,
        [Description("ixFixForDependsOn")]
        [Display(Name = "Dependent Milestone ID")]
        DependentMilestoneId,
        [Description("hrs")]
        [Display(Name = "Hours")]
        Hours,
        [Description("dt")]
        [Display(Name = "Date")]
        Date,
        [Description("nPercent")]
        [Display(Name = "Percent")]
        Percent,
        [Description("ixProjectPercentTime")]
        [Display(Name = "Project Percent Time ID")]
        ProjectPercentTimeId,
        [Description("dtEnd")]
        [Display(Name = "End Date")]
        EndDate
    }
}
