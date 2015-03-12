using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FogBugzApiWrapper.RequestObjects
{
    [XmlType("response")]
    public class LoginResult
    {
        [XmlElement("error")]
        [Display(Name = "Error")]
        public LoginError Error { get; set; }

        [XmlElement("token")]
        [Display(Name = "Login Token")]
        public string LoginToken { get; set; }
    }
}