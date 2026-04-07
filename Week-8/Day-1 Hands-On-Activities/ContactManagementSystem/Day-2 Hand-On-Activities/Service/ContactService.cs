using WebApplication12.Models;
using WebApplication12.Repository;

namespace WebApplication12.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;

        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Contact> GetAll() => _repo.GetAll();
        public Contact? GetById(int id) => _repo.GetById(id);
        public void Add(Contact contact) => _repo.Add(contact);
        public void Update(Contact contact) => _repo.Update(contact);
        public void Delete(int id) => _repo.Delete(id);
    }
}