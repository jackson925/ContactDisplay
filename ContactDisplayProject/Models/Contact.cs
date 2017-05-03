using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace ContactDisplayProject.Models
{
    // Declaring that incoming data is serializable
    [Serializable]
    // Declaring the expected root of the document
    // Declaring the Xml element type
    [XmlRoot("Contacts")][XmlType("Contacts")]
    public class Contact
    {

        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string MobilePhone { get; set; }

        public string HomePhone { get; set; }

        public string BusinessPhone { get; set; }

        public string Address { get; set; }

        public string Note { get; set; }
        
        public int Page { get; set; }
    }
}