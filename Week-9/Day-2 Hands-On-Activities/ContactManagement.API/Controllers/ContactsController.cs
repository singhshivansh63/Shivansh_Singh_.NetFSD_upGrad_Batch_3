using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ContactManagement.DAL11.Repository;
using ContactManagement.DAL11.Models;
using ContactManagement.API11.DTOs;

namespace ContactManagement.API11.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repo;
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(IContactRepository repo, ILogger<ContactsController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        // 🔹 GET ALL CONTACTS
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Fetching all contacts");

            var data = await _repo.GetAllAsync();

            _logger.LogInformation("Total contacts fetched: {Count}", data.Count);

            return Ok(data);
        }

        // 🔹 GET BY ID
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Fetching contact with ID: {Id}", id);

            var data = await _repo.GetByIdAsync(id);

            if (data == null)
            {
                _logger.LogWarning("Contact not found with ID: {Id}", id);

                return NotFound(new
                {
                    message = $"Contact with ID {id} not found"
                });
            }

            return Ok(data);
        }

        // 🔹 CREATE CONTACT (ADMIN ONLY)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ContactDTO dto)
        {
            _logger.LogInformation("Creating new contact: {@Contact}", dto);

            if (dto == null)
            {
                _logger.LogWarning("Create contact request is null");
                return BadRequest("Invalid contact data");
            }

            var contact = new ContactInfo
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                EmailId = dto.EmailId,
                MobileNo = dto.MobileNo,
                Designation = dto.Designation,
                CompanyId = dto.CompanyId,
                DepartmentId = dto.DepartmentId
            };

            var result = await _repo.AddAsync(contact);

            _logger.LogInformation("Contact created successfully with ID: {Id}", result.ContactId);

            return CreatedAtAction(nameof(GetById), new { id = result.ContactId }, result);
        }

        // 🔹 UPDATE CONTACT (ADMIN ONLY)
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, ContactDTO dto)
        {
            _logger.LogInformation("Updating contact ID: {Id}", id);

            if (dto == null || id != dto.ContactId)
            {
                _logger.LogWarning("Invalid update request. RouteId: {RouteId}, BodyId: {BodyId}", id, dto?.ContactId);

                return BadRequest("ID mismatch or invalid data");
            }

            var existing = await _repo.GetByIdAsync(id);

            if (existing == null)
            {
                _logger.LogWarning("Update failed. Contact not found: {Id}", id);

                return NotFound(new
                {
                    message = $"Contact with ID {id} not found"
                });
            }

            var updatedContact = new ContactInfo
            {
                ContactId = dto.ContactId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                EmailId = dto.EmailId,
                MobileNo = dto.MobileNo,
                Designation = dto.Designation,
                CompanyId = dto.CompanyId,
                DepartmentId = dto.DepartmentId
            };

            await _repo.UpdateAsync(updatedContact);

            _logger.LogInformation("Contact updated successfully: {Id}", id);

            return Ok(new
            {
                message = "Contact updated successfully",
                data = dto
            });
        }

        // 🔹 DELETE CONTACT (ADMIN ONLY)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Deleting contact ID: {Id}", id);

            var existing = await _repo.GetByIdAsync(id);

            if (existing == null)
            {
                _logger.LogWarning("Delete failed. Contact not found: {Id}", id);

                return NotFound(new
                {
                    message = $"Contact with ID {id} not found"
                });
            }

            await _repo.DeleteAsync(id);

            _logger.LogInformation("Contact deleted successfully: {Id}", id);

            return Ok(new
            {
                message = "Contact deleted successfully"
            });
        }
    }
}