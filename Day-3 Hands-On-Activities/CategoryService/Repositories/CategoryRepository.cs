using CategoryService.Data;
using CategoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace CategoryService.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDbContext _db;

        public CategoryRepository(CategoryDbContext db)
        {
            _db = db;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _db.Categories.FindAsync(id);
        }

        public async Task Add(Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
        }

        public async Task Update(Category category)
        {
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var contact = await _db.Categories.FindAsync(id);
            if (contact != null)
            {
                _db.Categories.Remove(contact);
                await _db.SaveChangesAsync();
            }
        }
    }
}