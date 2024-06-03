using Core.Contracts;
using Core.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepository(ApplicationDbContext context) : RepositoryBase<Category>(context), ICategoryRepository
    {
        public void CreateCategory(Category category) => Create(category);

        public void DeleteCategory(Category category) => Delete(category);

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync() => await GetAll().ToListAsync();

        public async Task<Category> GetCategoryAsync(Guid categoryId) =>
        await GetByCondition(c => c.CategoryId.Equals(categoryId)).FirstOrDefaultAsync();
    }
}