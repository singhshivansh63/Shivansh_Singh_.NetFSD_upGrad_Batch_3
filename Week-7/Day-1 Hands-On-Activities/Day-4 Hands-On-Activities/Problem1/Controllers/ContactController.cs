using WebApplication7.Models;
using WebApplication7.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }

        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);

            if (contact == null)
            {
                return Content("Contact Not Found");
            }
            return View(contact);
        }

        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            _contactService.AddContact(contactInfo);
            return RedirectToAction("ShowContacts");
        }
    }
}