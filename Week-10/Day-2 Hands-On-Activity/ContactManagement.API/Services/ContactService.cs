using ContactManagement.API.Interfaces;
using ContactManagement.API.Models;

namespace ContactManagement.API.Services
{
    public class ContactService : IContactService
    {
        private readonly List<ContactInfo> _contacts = new();
        private int _nextId = 1;

        public void AddContact(ContactInfo contact)
        {
            ValidateContact(contact);

            contact.Id = _nextId++;
            _contacts.Add(contact);
        }

        public void UpdateContact(int id, ContactInfo updatedContact)
        {
            ValidateContact(updatedContact);

            var existing = FindContactById(id);
            if (existing == null)
                throw new ArgumentException("Contact not found");

            existing.FirstName = updatedContact.FirstName;
            existing.LastName = updatedContact.LastName;
            existing.Email = updatedContact.Email;
            existing.MobileNumber = updatedContact.MobileNumber;
            existing.Designation = updatedContact.Designation;
            existing.CompanyId = updatedContact.CompanyId;
            existing.DepartmentId = updatedContact.DepartmentId;
        }

        public void DeleteContact(int id)
        {
            var contact = FindContactById(id);
            if (contact == null)
                throw new ArgumentException("Contact not found");

            contact.IsDeleted = true; // Soft delete
        }

        public List<ContactInfo> GetAllContacts()
        {
            return _contacts.Where(c => !c.IsDeleted).ToList();
        }

        // 🔹 Helper Methods
        private ContactInfo? FindContactById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        private static void ValidateContact(ContactInfo contact)
        {
            if (string.IsNullOrWhiteSpace(contact.FirstName))
                throw new ArgumentException("First Name required");

            if (string.IsNullOrWhiteSpace(contact.Email))
                throw new ArgumentException("Email required");
        }
    }
}