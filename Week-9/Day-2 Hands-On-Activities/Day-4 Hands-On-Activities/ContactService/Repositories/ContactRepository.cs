using ContactService.Data;
using ContactService.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _db;

        public ContactRepository(ContactDbContext db)
        {
            _db = db;
        }

        public async Task<List<Contact>> GetAll()
        {
            return await _db.Contacts.ToListAsync();
        }

        public async Task<Contact> GetById(int id)
        {
            return await _db.Contacts.FindAsync(id);
        }

        public async Task Add(Contact contact)
        {
            _db.Contacts.Add(contact);
            await _db.SaveChangesAsync();
        }

        public async Task Update(Contact contact)
        {
            _db.Contacts.Update(contact);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var contact = await _db.Contacts.FindAsync(id);
            if (contact != null)
            {
                _db.Contacts.Remove(contact);
                await _db.SaveChangesAsync();
            }
        }
    }
}