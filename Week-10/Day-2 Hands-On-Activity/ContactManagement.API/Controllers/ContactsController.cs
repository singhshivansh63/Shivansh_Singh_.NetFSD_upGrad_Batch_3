using Microsoft.AspNetCore.Mvc;
using ContactManagement.API.Interfaces;
using ContactManagement.API.Models;

namespace ContactManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(ContactInfo contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.AddContact(contact);
            return Ok("Contact added");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllContacts());
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ContactInfo contact)
        {
            _service.UpdateContact(id, contact);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteContact(id);
            return Ok("Deleted");
        }
    }
}
