using Application.Contracts;
using Application.DTOs;
using Application.Utils;
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
            var category = await EntityHelper
                            .GetEntityAndCheckIfItExists
                            (
                                categoryId,
                                _repository.Category.GetCategoryAsync
                            );
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
            var category = await EntityHelper
                            .GetEntityAndCheckIfItExists
                            (
                                id,
                                _repository.Category.GetCategoryAsync
                            );

            return category.Adapt<CategoryDto>();
        }

        public async Task UpdateCategoryAsync(Guid categoryId, CategoryDto model)
        {
            var category = await EntityHelper
                            .GetEntityAndCheckIfItExists
                            (
                                categoryId,
                                _repository.Category.GetCategoryAsync
                            );
            model.CategoryId = category.CategoryId;
            model.Adapt(category);
            await _repository.SaveAsync();
        }
    }
}