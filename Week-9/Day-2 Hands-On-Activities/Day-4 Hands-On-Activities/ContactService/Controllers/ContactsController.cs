using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ContactService.Services;
using ContactService.Models;

namespace ContactService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // 🔐 ALL APIs require token
    public class ContactsController : ControllerBase
    {
        private readonly ContactServiceLogic _service;

        public ContactsController(ContactServiceLogic service)
        {
            _service = service;
        }

        // ✅ USER + ADMIN (READ)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        // ✅ USER + ADMIN (READ)
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetById(id);
            return data == null ? NotFound() : Ok(data);
        }

        // 🔴 ADMIN ONLY
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Contact contact)
        {
            await _service.Add(contact);
            return Ok(contact);
        }

        // 🔴 ADMIN ONLY
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, Contact contact)
        {
            if (id != contact.ContactId) return BadRequest();

            await _service.Update(contact);
            return Ok(contact);
        }

        // 🔴 ADMIN ONLY
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}