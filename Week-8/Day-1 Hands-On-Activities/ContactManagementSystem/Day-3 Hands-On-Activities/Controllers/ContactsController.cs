using ContactManagement.API.DataAccess;
using ContactManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repository;

        public ContactsController(IContactRepository repo)
        {
            _repository = repo;
        }

        // GET: api/contacts
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        // GET: api/contacts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _repository.GetByIdAsync(id);
            if (contact == null)
                return NotFound($"Contact with ID {id} not found");

            return Ok(contact);
        }

        // POST: api/contacts
        [HttpPost]
        public async Task<IActionResult> Create(ContactInfo contact)
        {
            var created = await _repository.CreateAsync(contact);

            return CreatedAtAction(nameof(GetById), new { id = created.ContactId }, created);
        }

        // PUT: api/contacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ContactInfo contact)
        {
            var success = await _repository.UpdateAsync(id, contact);

            if (!success)
                return NotFound($"Contact ID {id} not found");

            return Ok(contact);
        }

        // DELETE: api/contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repository.DeleteAsync(id);

            if (!success)
                return NotFound($"Contact ID {id} does not exist");

            return Ok($"Contact {id} deleted");
        }
    }
}
