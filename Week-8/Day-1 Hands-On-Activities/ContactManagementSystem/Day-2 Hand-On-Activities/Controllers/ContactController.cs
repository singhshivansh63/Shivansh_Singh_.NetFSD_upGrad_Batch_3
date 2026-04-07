using Microsoft.AspNetCore.Mvc;
using WebApplication12.Models;
using WebApplication12.Services;

namespace WebApplication12.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

      
        public IActionResult Index()
        {
            return RedirectToAction("ShowContacts");
        }
 
        public IActionResult ShowContacts()
        {
            var contacts = _service.GetAll();
            return View(contacts);
        }

         
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (!ModelState.IsValid)
                return View(contact);

            _service.Add(contact);
            return RedirectToAction("ShowContacts");
        }

        
        public IActionResult EditContact(int id)
        {
            var contact = _service.GetById(id);

            if (contact == null)
                return NotFound();

            return View(contact);
        }

      
        [HttpPost]
        public IActionResult EditContact(Contact contact)
        {
            if (!ModelState.IsValid)
                return View(contact);

            _service.Update(contact);
            return RedirectToAction("ShowContacts");
        }

 
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("ShowContacts");
        }
    }
}