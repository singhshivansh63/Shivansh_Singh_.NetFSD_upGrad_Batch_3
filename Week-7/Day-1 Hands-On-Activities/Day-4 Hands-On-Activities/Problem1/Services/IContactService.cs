using WebApplication7.Models;
using System.Collections.Generic;

namespace WebApplication7.Services
{
    public interface IContactService
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);
        void AddContact(ContactInfo contact);
    }
}
