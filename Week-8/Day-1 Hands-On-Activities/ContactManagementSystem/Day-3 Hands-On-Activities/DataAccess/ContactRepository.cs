using ContactManagement.API.Models;

namespace ContactManagement.API.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        // Static In-Memory List
        public static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo { ContactId = 1, FirstName="John", LastName="Doe", EmailId="john@xyz.com",
                              MobileNo=9876543210, Designation="Manager", CompanyId=1, DepartmentId=1 },
            new ContactInfo { ContactId = 2, FirstName="Amit", LastName="Sharma", EmailId="amit@abc.com",
                              MobileNo=9123456780, Designation="Developer", CompanyId=2, DepartmentId=2 }
        };

        public async Task<IEnumerable<ContactInfo>> GetAllAsync()
        {
            return await Task.FromResult(contacts);
        }

        public async Task<ContactInfo?> GetByIdAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            return await Task.FromResult(contact);
        }

        public async Task<ContactInfo> CreateAsync(ContactInfo contact)
        {
            int newId = contacts.Count > 0 ? contacts.Max(c => c.ContactId) + 1 : 1;
            contact.ContactId = newId;

            contacts.Add(contact);
            return await Task.FromResult(contact);
        }

        public async Task<bool> UpdateAsync(int id, ContactInfo updatedContact)
        {
            var existing = contacts.FirstOrDefault(c => c.ContactId == id);
            if (existing == null)
                return false;

            existing.FirstName = updatedContact.FirstName;
            existing.LastName = updatedContact.LastName;
            existing.EmailId = updatedContact.EmailId;
            existing.MobileNo = updatedContact.MobileNo;
            existing.Designation = updatedContact.Designation;
            existing.CompanyId = updatedContact.CompanyId;
            existing.DepartmentId = updatedContact.DepartmentId;

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            if (contact == null)
                return false;

            contacts.Remove(contact);
            return true;
        }
    }
}