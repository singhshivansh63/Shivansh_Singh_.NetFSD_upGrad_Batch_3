using ContactManagement.DAL11.DbContext;
using ContactManagement.DAL11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ContactManagement.DAL11.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ContactRepository> _logger;

        public ContactRepository(AppDbContext context, ILogger<ContactRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        // 🔹 GET ALL
        public async Task<List<ContactInfo>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all contacts from database");

                return await _context.Contacts
                    .Include(c => c.Company)
                    .Include(c => c.Department)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all contacts");
                throw;
            }
        }

        // 🔹 GET BY ID
        public async Task<ContactInfo?> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Fetching contact by ID: {Id}", id);

                var contact = await _context.Contacts
                    .Include(c => c.Company)
                    .Include(c => c.Department)
                    .FirstOrDefaultAsync(x => x.ContactId == id);

                if (contact == null)
                {
                    _logger.LogWarning("Contact not found with ID: {Id}", id);
                }

                return contact;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching contact ID: {Id}", id);
                throw;
            }
        }

        // 🔹 ADD
        public async Task<ContactInfo> AddAsync(ContactInfo contact)
        {
            try
            {
                _logger.LogInformation("Adding new contact: {@Contact}", contact);

                await _context.Contacts.AddAsync(contact);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Contact created with ID: {Id}", contact.ContactId);

                return contact;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding contact");
                throw;
            }
        }

        // 🔹 UPDATE
        public async Task UpdateAsync(ContactInfo contact)
        {
            try
            {
                _logger.LogInformation("Updating contact ID: {Id}", contact.ContactId);

                var existing = await _context.Contacts.FindAsync(contact.ContactId);

                if (existing == null)
                {
                    _logger.LogWarning("Update failed. Contact not found: {Id}", contact.ContactId);
                    return;
                }

                _context.Entry(existing).CurrentValues.SetValues(contact);

                await _context.SaveChangesAsync();

                _logger.LogInformation("Contact updated successfully: {Id}", contact.ContactId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating contact ID: {Id}", contact.ContactId);
                throw;
            }
        }

        // 🔹 DELETE
        public async Task DeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Deleting contact ID: {Id}", id);

                var contact = await _context.Contacts.FindAsync(id);

                if (contact == null)
                {
                    _logger.LogWarning("Delete failed. Contact not found: {Id}", id);
                    return;
                }

                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Contact deleted successfully: {Id}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting contact ID: {Id}", id);
                throw;
            }
        }
    }
}