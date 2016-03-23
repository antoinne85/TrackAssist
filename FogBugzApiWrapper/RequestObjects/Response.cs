using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FogBugzApiWrapper.RequestObjects
{
    [XmlType("response")]
    [XmlRoot("response")]
    public class Response
    {
        [XmlArray("cases")]
        [XmlArrayItem("case")]
        public Case[] Cases { get; set; }

        [XmlArray("people")]
        [XmlArrayItem("person")]
        public User[] Users { get; set; }

        [XmlArray("statuses")]
        [XmlArrayItem("status")]
        public Status[] Statuses { get; set; }

        [XmlArray("areas")]
        [XmlArrayItem("area")]
        public Area[] Areas { get; set; }

        [XmlArray("categories")]
        [XmlArrayItem("category")]
        public Category[] Categories { get; set; }

        [XmlArray("filters")]
        [XmlArrayItem("filter")]
        public Filter[] Filters { get; set; }

        [XmlArray("intervals")]
        [XmlArrayItem("interval")]
        public Interval[] Intervals { get; set; }

        [XmlArray("mailboxes")]
        [XmlArrayItem("mailbox")]
        public Mailbox[] Mailboxes { get; set; }

        [XmlArray("fixfors")]
        [XmlArrayItem("fixfor")]
        public Milestone[] Milestones { get; set; }

        [XmlArray("priorities")]
        [XmlArrayItem("priority")]
        public Priority[] Priorities { get; set; }

        [XmlArray("projects")]
        [XmlArrayItem("project")]
        public Project[] Projects { get; set; }
    }

    [XmlType("project")]
    public class Project
    {
        [XmlElement("ixProject")]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [XmlElement("sProject")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [XmlElement("ixPersonOwner")]
        [Display(Name = "Owning User ID")]
        public int OwningUserId { get; set; }

        [XmlElement("sPersonOwner")]
        [Display(Name = "Owning User")]
        public string OwningUser { get; set; }

        [XmlElement("sEmail")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [XmlElement("sPhone")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [XmlElement("fInbox")]
        [Display(Name = "Inbox")]
        public bool Inbox { get; set; }

        [XmlElement("ixWorkflow")]
        [Display(Name = "Workflow ID")]
        public int WorkflowId { get; set; }

        [XmlElement("fDeleted")]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }
    }

    [XmlType("priority")]
    public class Priority
    {
        [XmlElement("ixPriority")]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [XmlElement("fDefault")]
        [Display(Name = "Default")]
        public bool Default { get; set; }

        [XmlElement("sPriority")]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }

    [XmlType("fixfor")]
    public class Milestone
    {
        [XmlElement("ixFixFor")]
        [Display(Name = "ID")]
        public string Id { get; set; }

        [XmlElement("sFixFor")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        //[XmlElement("fDeleted")]
        //[Display(Name = "Deleted")]
        //public bool? Deleted { get; set; }

        //[XmlElement("dt")]
        //[Display(Name = "Date")]
        //public DateTime? Date { get; set; }

        //[XmlElement("dtStart")]
        //[Display(Name = "Start Date")]
        //public DateTime? StartDate { get; set; }

        [XmlElement("sStartNote")]
        [Display(Name = "Start Note")]
        public string StartNote { get; set; }

        //[XmlElement("ixProject")]
        //[Display(Name = "Project ID")]
        //public int? ProjectId { get; set; }

        [XmlElement("sProject")]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        //[XmlElement("setixFixForDependency")]
        //[Display(Name = "Milestone Dependency ID")]
        //public int? MilestoneDependencyId { get; set; }

        //[XmlElement("fReallyDeleted")]
        //[Display(Name = "Really Deleted")]
        //public bool? ReallyDeleted { get; set; }
    }

    [XmlType("mailbox")]
    public class Mailbox
    {
        [XmlElement("ixMailbox")]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [XmlElement("sEmail")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [XmlElement("sEmailUser")]
        [Display(Name = "Email User")]
        public string EmailUser { get; set; }

        [XmlElement("sTemplate")]
        [Display(Name = "Template")]
        public string Template { get; set; }
    }

    [XmlType("interval")]
    public class Interval
    {
        [XmlElement("ixInterval")]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [XmlElement("ixPerson")]
        [Display(Name = "User ID")]
        public int UserId { get; set; }

        [XmlElement("ixBug")]
        [Display(Name = "Case Number")]
        public int CaseNumber { get; set; }

        [XmlElement("dtStart")]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        
        [Display(Name = "End Time")]
        public DateTime? EndTime { get; set; }

        [XmlElement("dtEnd")]
        public string ShimEndTime
        {
            get { return EndTime.HasValue ? EndTime.Value.ToString("u") : string.Empty; }
            set
            {
                DateTime result;
                if (DateTime.TryParse(value, out result))
                {
                    EndTime = result.ToUniversalTime();
                }
                else
                {
                    EndTime = null;
                }
            }
        }

        [XmlElement("sTitle")]
        [Display(Name = "Case Title")]
        public string CaseTitle { get; set; }
    }

    [XmlType("filter")]
    public class Filter
    {
        [XmlAttribute("type")]
        [Display(Name = "Type")]
        public FilterType Type { get; set; }

        [XmlAttribute("sFilter")]
        [Display(Name = "Filter ID")]
        public string Id { get; set; }

        [XmlText]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }

    public enum FilterType
    {
        [XmlEnum("builtin")]
        Builtin,
        [XmlEnum("shared")]
        Shared,
        [XmlEnum("saved")]
        Saved
    }

    [XmlType("category")]
    public class Category
    {
        [XmlElement("ixCategory")]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [XmlElement("sCategory")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [XmlElement("sPlural")]
        [Display(Name = "Plural")]
        public string Plural { get; set; }

        [XmlElement("ixStatusDefault")]
        [Display(Name = "Default Status ID")]
        public int DefaultStatusId { get; set; }

        [XmlElement("fIsScheduleItem")]
        [Display(Name = "Schedule Item")]
        public bool IsScheduleItem { get; set; }

        [XmlElement("fDeleted")]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [XmlElement("iOrder")]
        [Display(Name = "Order")]
        public int Order { get; set; }

        //TODO: IconType is actually an enumeration, figure out what the values are.
        [XmlElement("nIconType")]
        [Display(Name = "Icon Type")]
        public int IconType { get; set; }

        [XmlElement("ixAttachmentIcon")]
        [Display(Name = "Attachment Icon ID")]
        public int AttachmentIconId { get; set; }

        [XmlElement("ixStatusDefaultActive")]
        [Display(Name = "Default Active Status ID")]
        public int DefaultActiveStatusId { get; set; }
    }

    [XmlType("area")]
    public class Area
    {
        [XmlElement("ixArea")]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [XmlElement("sArea")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [XmlElement("ixProject")]
        [Display(Name = "Project ID")]
        public int ProjectId { get; set; }

        [XmlElement("ixPersonOwner")]
        [Display(Name = "Owner ID")]
        public int OwnerId { get; set; }

        [XmlElement("sPersonOwner")]
        [Display(Name = "Owner Name")]
        public string OwnerName { get; set; }

        [XmlElement("sProject")]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [XmlElement("nType")]
        [Display(Name = "Type")]
        public AreaType Type { get; set; }

        [XmlElement("cDoc")]
        [Display(Name = "Document Count")]
        public int DocumentCount { get; set; }
    }

    [XmlType("nType")]
    public enum AreaType
    {
        Normal = 0,
        NotSpam = 1,
        Undecided = 2,
        Spam = 3
    }

    [XmlType("status")]
    public class Status
    {
        [XmlElement("ixStatus")]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [XmlElement("sStatus")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [XmlElement("ixCategory")]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }

        [XmlElement("fWorkDone")]
        [Display(Name = "Work Done")]
        public bool WorkDone { get; set; }

        [XmlElement("fResolved")]
        [Display(Name = "Resolved")]
        public bool Resolved { get; set; }

        [XmlElement("fDuplicate")]
        [Display(Name = "Duplicate")]
        public bool Duplicate { get; set; }

        [XmlElement("fDeleted")]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [XmlElement("fReactivate")]
        [Display(Name = "Reactivate")]
        public bool Reactivate { get; set; }

        [XmlElement("iOrder")]
        [Display(Name = "Order")]
        public int Order { get; set; }
    }

    [XmlType("person")]
    public class User
    {
        [XmlElement("ixPerson")]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [XmlElement("sFullName")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [XmlElement("sPhone")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [XmlElement("fAdministrator")]
        [Display(Name = "Admin")]
        public bool Administrator { get; set; }

        [XmlElement("fCommunity")]
        [Display(Name = "Community User")]
        public bool CommunityUser { get; set; }

        [XmlElement("fDeleted")]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [XmlElement("fNotify")]
        [Display(Name = "Notify")]
        public bool Notify { get; set; }

        [XmlElement("sHomepage")]
        [Display(Name = "Homepage")]
        public string Homepage { get; set; }

        [XmlElement("sLocale")]
        [Display(Name = "Localse")]
        public string Locale { get; set; }

        [XmlElement("sLanguage")]
        [Display(Name = "Language")]
        public string Language { get; set; }

        [XmlElement("sTimeZoneKey")]
        [Display(Name = "Time Zone Key")]
        public string TimeZoneKey { get; set; }

        [XmlElement("sLDAPUid")]
        [Display(Name = "LDAP ID")]
        public string LdapId { get; set; }

        [Display(Name = "Last Activity")]
        public DateTime? LastActivity { get; set; }

        [XmlElement("dtLastActivity")]
        public string ShimLastActivity
        {
            get { return LastActivity.HasValue ? LastActivity.Value.ToString("u") : string.Empty; }
            set
            {
                DateTime result;
                if (DateTime.TryParse(value, out result))
                {
                    LastActivity = result.ToUniversalTime();
                }
                else
                {
                    LastActivity = null;
                }
            }
        }

        [XmlElement("fRecurseBugChildren")]
        [Display(Name = "Recurse Case Children")]
        public bool RecurseCaseChildren { get; set; }

        [XmlElement("fPaletteExpanded")]
        [Display(Name = "Pallete Expanded")]
        public bool PaletteExpanded { get; set; }

        [XmlElement("ixBugWorkingOn")]
        [Display(Name = "Currently Working on Case")]
        public int CurrentlyWorkingOnCaseId { get; set; }

        [XmlElement("sFrom")]
        [Display(Name = "From")]
        public string From { get; set; }
    }
}
