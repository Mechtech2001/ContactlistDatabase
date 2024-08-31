using ContactlistDatabase.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactlistDatabase.Controllers
{
    public class ContactsController : Controller
    {
        //create ContactsContext object
        private ContactsContext context { get; set; }
        //allows controller access to the data base
        public ContactsController(ContactsContext ctx) => context = ctx;
        //gets empty data set for add contact form
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Contacts());
        }
        //sends user to the edit page
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var contacts = context.Contacts.Find(id);
            return View(contacts);
        }
        //sends the user to either the a empty form or to edit an existing form and edits the database
        [HttpPost]
        public IActionResult Edit(Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                if (contacts.ContactsId == 0)
                    context.Contacts.Add(contacts);
                else
                    context.Contacts.Update(contacts);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (contacts.ContactsId == 0) ? "Add" : "Edit";
                return View(contacts);
            }
        }
        //sends user to the delete page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contacts = context.Contacts.Find(id);
            return View(contacts);
        }
        //deletes selected data from database
        public IActionResult Delete(Contacts contacts)
        {
            context.Contacts.Remove(contacts);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
