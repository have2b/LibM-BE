using Core.Entities;

namespace Core.Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryAsync(Guid categoryId);
        void CreateCategory(Category category);
        void DeleteCategory(Category category);
    }
}