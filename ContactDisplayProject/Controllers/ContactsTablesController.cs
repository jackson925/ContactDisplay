using System.Web.Mvc;
using ContactDisplayProject.Models;
using System.Linq;
using PagedList;
namespace ContactDisplayProject.Controllers
{
    public class ContactsTablesController : Controller
    {
        // New XmlConverter globally for use in more than one action
        XmlConverter con = new XmlConverter();

        // GET: ContactsTables 
        // Nullable page number param
        public ActionResult Index(int? page)
        {
            // Get contacts
            var contacts = con.GetContacts();
            //Ensure page has value
            int pageNumber = (page ?? 1);
            // Save page number in session
            ViewBag.Page = page;
            //Return model to view, page length, and current value
            return View(contacts.ToPagedList(page ?? 1,10));
        }

        // GET: ContactsTables/Details/name&page
        // Name param, and nullable page param
        public ActionResult Details(string name, int? page)
        {
            // Retrieving the contact whose first name matches the one passed in
            var contactDetails = con.GetContacts().Find(u => u.FirstName == name);
            // Ensure its not null
            if (contactDetails != null)
            {
                int pagenum = (page ?? 1);
                // Assign passed current page value to Contact Object
                contactDetails.Page = pagenum;
                // Pass Contact to Details View
                return View(contactDetails);
            }
            // Return empty view if model is null
            else return View();
        }
    }
}
