using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using FogBugzApiWrapper.Data;

namespace FogBugzApiWrapper.RequestObjects
{
    [XmlType("case")]
    public class Case
    {
        [XmlElement("ixBug")]
        [Display(Name = "Case Number")]
        public int CaseId { get; set; }

        [XmlAttribute("operations")]
        public string OperationsRaw { get; set; }
        [Display(Name = "Available Operations")]
        public List<Operation> Operations { get; set; }

        [XmlElement("ixBugChildren")]
        public string ChildCaseNumbersRaw { get; set; }
        [Display(Name = "Child Case Numbers")]
        public List<int> ChildCaseNumbers { get; set; }

        //[XmlAttribute("tags")]
        //public string TagsRaw { get; set; }
        [Display(Name ="Tags")]
        [XmlArray("tags")]
        [XmlArrayItem("tag")]
        public List<string> Tags { get; set; }

        [XmlElement("fOpen")]
        [Display(Name = "Is Open")]
        public bool? IsOpen { get; set; }

        [XmlElement("sTitle")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [XmlElement("sOriginalTitle")]
        public string OriginalTitle { get; set; }

        [XmlElement("sLatestTextSummary")]
        public string LatestTextSummary { get; set; }

        [XmlElement("ixBugEventLatestText")]
        public int? LatestEventTextId { get; set; }

        [XmlElement("ixProject")]
        public int? ProjectId { get; set; }

        [XmlElement("sProject")]
        public string ProjectName { get; set; }

        [XmlElement("ixArea")]
        public int? AreaId { get; set; }

        [XmlElement("sArea")]
        public string AreaName { get; set; }

        [XmlElement("ixGroup")]
        public int? GroupId { get; set; }

        [XmlElement("ixPersonAssignedTo")]
        public int? AssignedToUserId { get; set; }

        [XmlElement("sPersonAssignedTo")]
        public string AssignedToUserName { get; set; }

        [XmlElement("sEmailAssignedTo")]
        public string AssignedToEmailAddress { get; set; }

        [XmlElement("ixPersonOpenedBy")]
        public int? OpenedByUserId { get; set; }

        [XmlElement("ixPersonResolvedBy")]
        public int? ResolvedByUserId { get; set; }

        [XmlElement("ixPersonClosedBy")]
        public int? ClosedByUserId { get; set; }

        [XmlElement("ixPersonLastEditedBy")]
        public int? LastEditedByUserId { get; set; }

        [XmlElement("ixStatus")]
        public int? StatusId { get; set; }

        [XmlElement("ixBugDuplicates")]
        public string DuplicateCaseIdsRaw { get; set; }
        public List<int> DuplicateCaseIds { get; set; }

        [XmlElement("ixBugOriginal")]
        public int? OriginalCaseId { get; set; }

        [XmlElement("sStatus")]
        public string StatusName { get; set; }

        [XmlElement("ixPriority")]
        public int? PriorityId { get; set; }

        [XmlElement("sPriority")]
        public string PriorityName { get; set; }

        [XmlElement("ixFixFor")]
        public int? MilestoneId { get; set; }

        [XmlElement("sFixFor")]
        public string MilestoneName { get; set; }

        [XmlElement("dtFixFor")]
        public DateTime? MilestoneDate { get; set; }

        [XmlElement("sVersion")]
        public string Version { get; set; }

        [XmlElement("sComputer")]
        public string Computer { get; set; }

        [XmlElement("hrsOrigEst")]
        public double? OriginalEstimateInHours { get; set; }

        [XmlElement("hrsCurrEst")]
        public double? CurrentEstimateInHours { get; set; }

        [XmlElement("hrsElapsed")]
        public double? ElapsedHours { get; set; }

        [XmlElement("c")]
        public int? NumOccurrences { get; set; }

        [XmlElement("sCustomerEmail")]
        public string CustomerEmail { get; set; }

        [XmlElement("ixMailbox")]
        public int? MailboxId { get; set; }

        [XmlElement("ixCategory")]
        public int? CategoryId { get; set; }

        [XmlElement("sCategory")]
        public string CategoryName { get; set; }

        [XmlElement("dtOpened")]
        public DateTime? DateOpened { get; set; }

        [XmlElement("dtResolved")]
        public DateTime? DateResolved { get; set; }

        [XmlElement("dtClosed")]
        public DateTime? DateClosed { get; set; }

        [XmlElement("ixBugEventLatest")]
        public int? LatestBugEventId { get; set; }

        [XmlElement("dtLastUpdated")]
        public DateTime? DateLastUpdated { get; set; }

        [XmlElement("fReplied")]
        public bool? RepliedTo { get; set; }

        [XmlElement("fForwarded")]
        public bool? Forwarded { get; set; }

        [XmlElement("sTicket")]
        public string CustomerAccessTicket { get; set; }

        [XmlElement("ixDiscussTopic")]
        public int? TopicDiscussionId { get; set; }

        [XmlElement("dtDue")]
        public DateTime? DateDue { get; set; }

        [XmlElement("sReleaseNotes")]
        public string ReleaseNotes { get; set; }

        [XmlElement("ixBugEventLastView")]
        public int? BugEventLastViewId { get; set; }

        [XmlElement("dtLastView")]
        public DateTime DateLastViewed { get; set; }

        [XmlElement("ixRelatedBugs")]
        public string RelatedBugIdsRaw { get; set; }
        public List<int> RelatedBugIds { get; set; }

        [XmlElement("sScoutDescription")]
        public string ScoutDescription { get; set; }

        [XmlElement("sScoutMessage")]
        public string ScoutMessage { get; set; }

        [XmlElement("fScoutStopReporting")]
        public bool? ScoutIsReporting { get; set; }

        [XmlElement("dtLastOccurrence")]
        public DateTime? DateLastOccurrence { get; set; }

        [XmlElement("fSubscribed")]
        public bool? Subscribed { get; set; }
    }
}