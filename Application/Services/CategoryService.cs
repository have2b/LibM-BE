using Application.Contracts;
using Application.DTOs;
using Core.Contracts;
using Core.Entities;
using Mapster;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repository;

        public CategoryService(IRepositoryManager repository)
        {
            _repository = repository;
        }
        public async Task<CategoryDto> CreateCategoryAsync(CategoryDto model)
        {
            var categoryEntity = model.Adapt<Category>();

            _repository.Category.CreateCategory(categoryEntity);
            await _repository.SaveAsync();

            return categoryEntity.Adapt<CategoryDto>();
        }

        public async Task DeleteCategoryAsync(Guid categoryId)
        {
            var category = await GetCategoryAndCheckIfItExists(categoryId);
            _repository.Category.DeleteCategory(category);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _repository.Category.GetAllCategoriesAsync();

            var categoriesDto = categories.Adapt<IEnumerable<CategoryDto>>();

            return categoriesDto;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid id)
        {
            var category = await GetCategoryAndCheckIfItExists(id);

            return category.Adapt<CategoryDto>();
        }

        public async Task UpdateCategoryAsync(Guid categoryId, CategoryDto model)
        {
            var category = await GetCategoryAndCheckIfItExists(categoryId);

            model.Adapt(category);
            await _repository.SaveAsync();
        }

        private async Task<Category> GetCategoryAndCheckIfItExists(Guid categoryId)
        {
            var category = await _repository.Category.GetCategoryAsync(categoryId) ?? throw new Exception("Category not found");

            return category;
        }
    }
}