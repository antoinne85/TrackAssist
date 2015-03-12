using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FogBugzApiWrapper.Annotations;

namespace FogBugzApiWrapper.Data
{
    public enum Command
    {
        [Description("logon")]
        [Display(Name = "Login")]
        [RequiredArguments(Argument.Email, Argument.Password)]
        Login,

        [Description("logoff")]
        [Display(Name = "Logout")]
        [RequiredArguments(Argument.LoginToken)]
        Logout,

        [Description("listFilters")]
        [Display(Name = "List Filters")]
        ListFilters,

        [Description("search")]
        [Display(Name = "Search")]
        [OptionalArguments(Argument.Query, Argument.ColumnsToReturn, Argument.MaxResults)]
        [LooseArguments]
        Search,

        [Description("new")]
        [Display(Name = "Create New Case")]
        [LooseArguments]
        CreateCase,

        [Description("edit")]
        [Display(Name = "Edit Case")]
        [LooseArguments]
        EditCase,

        [Description("assign")]
        [Display(Name = "Assign Case")]
        [LooseArguments]
        AssignCase,

        [Description("reactivate")]
        [Display(Name = "Reactivate Case")]
        [LooseArguments]
        ReactivateCase,

        [Description("reopen")]
        [Display(Name = "Reopen Case")]
        [LooseArguments]
        ReopenCase,

        [Description("resolve")]
        [Display(Name = "Resolve Case")]
        ResolveCase,

        [Description("close")]
        [Display(Name = "Close Case")]
        CloseCase,

        [Description("email")]
        [Display(Name = "Email")]
        Email,

        [Description("reply")]
        [Display(Name = "Reply")]
        Reply,

        [Description("forward")]
        [Display(Name = "Forward")]
        Forward,

        [Description("listProjects")]
        [Display(Name = "List Projects")]
        [OptionalArguments(Argument.ShowOnlyEditable, Argument.ProjectId, Argument.IncludeDeleted)]
        ListProjects,

        [Description("listAreas")]
        [Display(Name = "ListAreas")]
        [OptionalArguments(Argument.ShowOnlyEditable, Argument.ProjectId, Argument.AreaId)]
        ListAreas,

        [Description("listCategories")]
        [Display(Name = "List Categories")]
        ListCategories,

        [Description("listPriorities")]
        [Display(Name = "List Priorities")]
        ListPriorities,

        [Description("listPeople")]
        [Display(Name = "List Users")]
        [OptionalArguments(Argument.IncludeActive, Argument.IncludeNormal, Argument.IncludeDeleted, Argument.IncludeCommunity, Argument.IncludeVirtual)]
        ListUsers,

        [Description("listStatuses")]
        [Display(Name = "List Statuses")]
        [OptionalArguments(Argument.CategoryId, Argument.IsResolved)]
        ListStatuses,

        [Description("listFixFors")]
        [Display(Name = "List Milestones")]
        [OptionalArguments(Argument.ProjectId, Argument.MilestoneId, Argument.IncludeDeleted, Argument.IncludeReallyDeleted)]
        ListMilestones,

        [Description("listMailboxes")]
        [Display(Name = "List Mailboxes")]
        ListMailboxes,

        [Description("listWikis")]
        [Display(Name = "List Wikis")]
        ListWikis,

        [Description("listTemplates")]
        [Display(Name = "List Templates")]
        ListTemplates,

        [Description("listSnippets")]
        [Display(Name = "List Snippets")]
        [OptionalArguments(Argument.GlobalOnly)]
        ListSnippets,

        [Description("newProject")]
        [Display(Name = "Create New Project")]
        [RequiredArguments(Argument.ProjectName, Argument.PrimaryContactId, Argument.AllowPublicSubmit, Argument.UseInbox)]
        CreateNewProject,

        [Description("newArea")]
        [Display(Name = "Create New Area")]
        [RequiredArguments(Argument.ProjectId, Argument.AreaName, Argument.PrimaryContactId)]
        CreateNewArea,

        [Description("newPerson")]
        [Display(Name = "Create New User")]
        [RequiredArguments(Argument.Email, Argument.FullName)]
        [OptionalArguments(Argument.UserType, Argument.IsActive, Argument.Password, Argument.LocaleName, Argument.Language, Argument.TimeZoneKey, Argument.SnippetKey, Argument.Notify, Argument.PhoneNumber, Argument.Homepage, Argument.Deleted)]
        CreateNewUser,

        [Description("newFixFor")]
        [Display(Name = "Create New Milestone")]
        [RequiredArguments(Argument.ProjectId, Argument.MilestoneName)]
        [OptionalArguments(Argument.ReleaseDate, Argument.StartDate, Argument.StartNote, Argument.Assignable)]
        CreateNewMilestone,

        [Description("editPerson")]
        [Display(Name = "Edit User")]
        [RequiredArguments(Argument.UserId)]
        [OptionalArguments(Argument.Email, Argument.FullName, Argument.UserType, Argument.IsActive, Argument.Password, Argument.LocaleName, Argument.Language, Argument.TimeZoneKey, Argument.SnippetKey, Argument.Notify, Argument.PhoneNumber, Argument.Homepage, Argument.Deleted)]
        EditUser,

        [Description("viewProject")]
        [Display(Name = "View Project")]
        [RequiredArguments(Argument.ProjectId)]
        [RequiredArguments(Argument.ProjectName)]
        ViewProject,

        [Description("viewArea")]
        [Display(Name = "View Area")]
        [RequiredArguments(Argument.AreaId)]
        [RequiredArguments(Argument.AreaName, Argument.ProjectId)]
        ViewArea,

        [Description("viewPerson")]
        [Display(Name = "View User")]
        [OptionalArguments(Argument.UserId, Argument.Email)]
        ViewUser,

        [Description("viewFixFor")]
        [Display(Name = "View Milestone")]
        [RequiredArguments(Argument.MilestoneId)]
        [RequiredArguments(Argument.MilestoneName, Argument.ProjectId)]
        ViewMilestone,

        [Description("viewCategory")]
        [Display(Name = "View Category")]
        [RequiredArguments(Argument.CategoryId)]
        ViewCategory,

        [Description("viewPriority")]
        [Display(Name = "View Priority")]
        [RequiredArguments(Argument.PriorityId)]
        ViewPriority,

        [Description("viewStatus")]
        [Display(Name = "View Status")]
        [RequiredArguments(Argument.StatusId)]
        [RequiredArguments(Argument.StatusName, Argument.CategoryId)]
        ViewStatus,

        [Description("viewMailbox")]
        [Display(Name = "View Mailbox")]
        [RequiredArguments(Argument.MailboxId)]
        ViewMailbox,

        [Description("viewTemplate")]
        [Display(Name = "View Template")]
        [RequiredArguments(Argument.TemplateId)]
        ViewTemplate,

        [Description("addFixForDependency")]
        [Display(Name = "Add Milestone Dependency")]
        [RequiredArguments(Argument.MilestoneId, Argument.DependentMilestoneId)]
        AddMilestoneDependency,

        [Description("deleteFixForDependency")]
        [Display(Name = "Delete Milestone Dependency")]
        [RequiredArguments(Argument.MilestoneId, Argument.DependentMilestoneId)]
        DeleteMilestoneDependency,

        [Description("listWorkingSchedule")]
        [Display(Name = "List Working Schedule")]
        [OptionalArguments(Argument.UserId)]
        ListWorkingSchedule,

        [Description("wsDateFromHours")]
        [Display(Name = "Get Due Date From Working Hours")]
        [RequiredArguments(Argument.Hours, Argument.Date)]
        [OptionalArguments(Argument.UserId)]
        GetDueDateFromWorkingHours,

        [Description("listProjectPercentTime")]
        [Display(Name = "List Project Percent Time")]
        [OptionalArguments(Argument.UserId)]
        ListProjectPercentTime,

        [Description("addProjectPercentTime")]
        [Display(Name = "Add Project Percent Time")]
        [RequiredArguments(Argument.ProjectId, Argument.Percent)]
        AddProjectPercentTime,

        [Description("editProjectPercentTime")]
        [Display(Name = "Edit Project Percent Time")]
        [RequiredArguments(Argument.ProjectPercentTimeId)]
        EditProjectPercentTime,

        [Description("deleteProjectPercentTime")]
        [Display(Name = "Delete Project Percent Time")]
        DeleteProjectPercentTime,

        [Description("startWork")]
        [Display(Name = "Start Working On")]
        [RequiredArguments(Argument.CaseNumber)]
        StartWork,

        [Description("stopWork")]
        [Display(Name = "Stop Working On")]
        [NoArguments]
        StopWork,

        [Description("newInterval")]
        [Display(Name = "New Interval")]
        [RequiredArguments(Argument.CaseNumber, Argument.StartDate, Argument.EndDate)]
        NewInterval,

        [Description("listIntervals")]
        [Display(Name = "List Intervals")]
        [OptionalArguments(Argument.UserId, Argument.CaseNumber, Argument.StartDate, Argument.EndDate)]
        ListIntervals,

        //TODO: Source Control annotations.
        [Description("newCheckin")]
        [Display(Name = "New Checkin")]
        NewCheckin,

        [Description("listCheckins")]
        [Display(Name = "List Checkins")]
        ListCheckins,

        [Description("listTags")]
        [Display(Name = "List Tags")]
        ListTags,

        [Description("editFixFor")]
        [Display(Name = "Edit Milestone")]
        [RequiredArguments(Argument.MilestoneId, Argument.MilestoneName)]
        [OptionalArguments(Argument.ReleaseDate, Argument.StartDate, Argument.StartNote, Argument.Assignable)]
        EditMilestone,

        [Description("newWiki")]
        [Display(Name = "New Wiki")]
        NewWikiw,

        [Description("editWiki")]
        [Display(Name = "Edit Wiki")]
        EditWiki,

        [Description("deleteWiki")]
        [Display(Name = "Delete Wiki")]
        DeleteWiki,

        [Description("undeleteWiki")]
        [Display(Name = "Undelete Wiki")]
        UndeleteWiki,

        [Description("newArticle")]
        [Display(Name = "New Wiki Article")]
        NewWikiArticle,

        [Description("editArticle")]
        [Display(Name = "Edit Wiki Article")]
        EditWikiArticle,

        [Description("listArticles")]
        [Display(Name = "List Wiki Articles")]
        ListWikiArticles,

        [Description("listRevisions")]
        [Display(Name = "List Wiki Article Revisions")]
        ListWikiArticleRevisions,

        [Description("viewArticle")]
        [Display(Name = "View Wiki Article")]
        ViewWikiArticle,

        [Description("listTemplates")]
        [Display(Name = "ListWikiTemplates")]
        ListWikiTemplates,

        [Description("listTemplateRevisions")]
        [Display(Name = "List Wiki Template Revisions")]
        ListWikiTemplateRevisions,

        [Description("viewTemplate")]
        [Display(Name = "View Wiki Template")]
        ViewWikiTemplate,

        [Description("deleteTemplate")]
        [Display(Name = "Delete Wiki Template")]
        DeleteWikiTEmplate,

        [Description("newTemplate")]
        [Display(Name = "New Wiki Template")]
        NewWikiTemplate,

        [Description("editTemplate")]
        [Display(Name = "Edit Wiki Template")]
        EditWikiTemplate,

        [Description("wikiFileUpload")]
        [Display(Name = "Wiki File Upload")]
        WikiFileUpload,

        [Description("listDiscussionGroups")]
        [Display(Name = "List Discussion Groups")]
        ListDiscussionGroups,

        [Description("listDiscussion")]
        [Display(Name = "List Discussion")]
        ListDiscussion,

        [Description("listDiscussTopic")]
        [Display(Name = "List Discuss Topic")]
        ListDiscussTopic,

        [Description("listScoutCase")]
        [Display(Name = "List Scout Case")]
        ListScoutCase,

        [Description("subscribe")]
        [Display(Name = "Subscribe")]
        Subscribe,

        [Description("unsubscribe")]
        [Display(Name = "Unsubscribe")]
        Unsubscribe,

        [Description("addEmailAddress")]
        [Display(Name = "Add Email Address")]
        AddEmailAddress,

        [Description("deleteEmailAddress")]
        [Display(Name = "Delete Email Address")]
        DeleteEmailAddress,

        [Description("findEmailAddress")]
        [Display(Name = "Find Email Address")]
        FindEmailAddress,

        [Description("view")]
        [Display(Name = "View")]
        View,

        [Description("star")]
        [Display(Name = "Star")]
        Star,

        [Description("unstar")]
        [Display(Name = "Unstar")]
        Unstar,

        [Description("viewSettings")]
        [Display(Name = "View Settings")]
        ViewSettings,

        [Description("viewSiteSettings")]
        [Display(Name = "View Site Settings")]
        ViewSiteSettings,

        [Description("viewUserTimelineReport")]
        [Display(Name = "View User Timeline Report")]
        ViewUserTimelineReport,

        [Description("viewUserShipDateReport")]
        [Display(Name = "View User Ship Date Report")]
        ViewUserShipDateReport,

        [Description("viewShipDateReport")]
        [Display(Name = "View Ship Date Report")]
        ViewShipDateReport,

        [Description("viewHoursRemainingReport")]
        [Display(Name = "View Hours Remaining Report")]
        ViewHoursRemainingReport,

        [Description("listShipDate")]
        [Display(Name = "List Ship Date")]
        ListShipDate,

        [Description("viewEstimator")]
        [Display(Name = "View Estimator")]
        ViewEstimator,

        [Description("adminSetCaseNumber")]
        [Display(Name = "Set Case Number")]
        SetCaseNumber,

    }
}