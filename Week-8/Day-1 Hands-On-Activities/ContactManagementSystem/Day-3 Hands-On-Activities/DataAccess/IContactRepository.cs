using ContactManagement.API.Models;

namespace ContactManagement.API.DataAccess
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactInfo>> GetAllAsync();
        Task<ContactInfo?> GetByIdAsync(int id);
        Task<ContactInfo> CreateAsync(ContactInfo contact);
        Task<bool> UpdateAsync(int id, ContactInfo updatedContact);
        Task<bool> DeleteAsync(int id);
    }
}