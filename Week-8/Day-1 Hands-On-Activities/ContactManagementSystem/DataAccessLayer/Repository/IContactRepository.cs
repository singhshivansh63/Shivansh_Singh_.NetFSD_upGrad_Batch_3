using DataAccessLayer.Models;

namespace DataAccessLayer.Repository
{
    public interface IContactRepository
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);
        void AddContact(ContactInfo contact);
        void UpdateContact(ContactInfo contact);
        void DeleteContact(int id);

        // Dropdowns
        List<Company> GetCompanies();
        List<Department> GetDepartments();
    }
}