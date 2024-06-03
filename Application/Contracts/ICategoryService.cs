using Application.DTOs;

namespace Application.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(Guid id);
        Task<CategoryDto> CreateCategoryAsync(CategoryDto model);
        Task UpdateCategoryAsync(Guid categoryId, CategoryDto model);
        Task DeleteCategoryAsync(Guid categoryId);
    }
}