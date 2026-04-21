using ContactManagement.API.Models;

namespace ContactManagement.API.Interfaces
{
    public interface IContactService
    {
        void AddContact(ContactInfo contact);
        void UpdateContact(int id, ContactInfo contact);
        void DeleteContact(int id);
        List<ContactInfo> GetAllContacts();
    }
}