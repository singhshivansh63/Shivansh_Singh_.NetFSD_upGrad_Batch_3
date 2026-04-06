using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AppUILayer.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;

        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }

        [Route("list")]
        public IActionResult ShowContacts()
        {
            var contacts = _repo.GetAllContacts();
            return View(contacts);
        }

        [Route("add")]
        public IActionResult AddContact()
        {
            ViewBag.Companies = _repo.GetCompanies();
            ViewBag.Departments = _repo.GetDepartments();
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddContact(ContactInfo contact)
        {
            _repo.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [Route("edit/{id}")]
        public IActionResult EditContact(int id)
        {
            var contact = _repo.GetContactById(id);
            ViewBag.Companies = _repo.GetCompanies();
            ViewBag.Departments = _repo.GetDepartments();
            return View(contact);
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult EditContact(ContactInfo contact)
        {
            _repo.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [Route("delete/{id}")]
        public IActionResult DeleteContact(int id)
        {
            _repo.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }
    }
}