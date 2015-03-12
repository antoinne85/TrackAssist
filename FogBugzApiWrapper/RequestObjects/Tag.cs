using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FogBugzApiWrapper.RequestObjects
{
    [XmlType("tag")]
    public class Tag
    {
        [XmlElement("ixTag")]
        [Display(Name ="Tag ID")]
        public int? TagId { get; set; }

        [XmlElement("cTagUses")]
        [Display(Name ="Number of Times Used")]
        public int? NumTimesUsed { get; set; }

        [XmlElement("sTag")]
        [Display(Name = "Value")]
        public string Value { get; set; }
    }
}