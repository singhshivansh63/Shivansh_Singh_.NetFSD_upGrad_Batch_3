using ContactManagement.DAL11.Models;

namespace ContactManagement.DAL11.Repository
{
    public interface IContactRepository
    {
        Task<List<ContactInfo>> GetAllAsync();
        Task<ContactInfo> GetByIdAsync(int id);
        Task<ContactInfo> AddAsync(ContactInfo contact);
        Task UpdateAsync(ContactInfo contact);
        Task DeleteAsync(int id);
    }
}