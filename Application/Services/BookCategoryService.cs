using Application.Contracts;
using Application.DTOs;
using Core.Contracts;
using Core.Exceptions;
using Mapster;

namespace Application.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly IRepositoryManager _repository;

        public BookCategoryService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public Task Add(Guid bookId, List<Guid> categoryIds)
        {
            _repository.BookCategory.Add(bookId, categoryIds);

            return Task.CompletedTask;
        }

        public async Task<List<BookDto>> GetBooksByCategory(Guid categoryId)
        {
            var books = await _repository.BookCategory.GetBooksByCategory(categoryId);
            return books.Adapt<List<BookDto>>();
        }

        public async Task<List<CategoryDto>> GetCategoriesByBook(Guid bookId)
        {
            var categories = await _repository.BookCategory.GetCategoriesByBook(bookId);
            return categories.Adapt<List<CategoryDto>>();
        }

        public Task RemoveByBook(Guid bookId)
        {
            _repository.BookCategory.RemoveByBook(bookId);

            return Task.CompletedTask;
        }

        public Task RemoveByCategory(Guid categoryId)
        {
            _repository.BookCategory.RemoveByCategory(categoryId);

            return Task.CompletedTask;
        }
    }
}