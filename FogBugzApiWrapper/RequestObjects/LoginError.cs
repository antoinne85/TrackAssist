using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FogBugzApiWrapper.RequestObjects
{
    [XmlType("error")]
    public class LoginError
    {
        [XmlAttribute("code")]
        [Display(Name = "Error Code")]
        public int ErrorCode { get; set; }

        [XmlText]
        [Display(Name = "Error Message")]
        public string Message { get; set; }
    }
}