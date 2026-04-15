using CategoryService.Models;
using CategoryService.Repositories;

namespace CategoryService.Services
{
    public class CategoryServiceLogic
    {
        private readonly ICategoryRepository _repo;

        public CategoryServiceLogic(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Category>> GetAll() => _repo.GetAll();

        public Task<Category> GetById(int id) => _repo.GetById(id);

        public Task Add(Category contact) => _repo.Add(contact);

        public Task Update(Category contact) => _repo.Update(contact);

        public Task Delete(int id) => _repo.Delete(id);
    }
}