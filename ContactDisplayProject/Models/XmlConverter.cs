using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace ContactDisplayProject.Models
{
    public class XmlConverter
    {
       public List<Contact> GetContacts()
        {
            // Path to xml file in App_data
            string path = @"D:\Dev Projects\ContactDisplayProject\ContactDisplayProject\App_Data\XMldataSet.xml";
            DataSet ds = new DataSet();
            // Read xml into the dataset
            ds.ReadXml(path);
            var contactList = new List<Contact>();
            // Selecting the values at every row in every contactset, and assigning them to
            // a new Contact from "contactList"
            contactList = (from contactSet in ds.Tables[0].AsEnumerable()
                           select new Contact
                           {
                               FirstName = contactSet[0].ToString(),
                               LastName = contactSet[1].ToString(),
                               Email = contactSet[2].ToString(),
                               MobilePhone = contactSet[3].ToString(),
                               HomePhone = contactSet[4].ToString(),
                               BusinessPhone = contactSet[5].ToString(),
                               Address = contactSet[6].ToString(),
                               Note = contactSet[7].ToString()
                               

                           }).ToList();
            return contactList;
        }

    }
}