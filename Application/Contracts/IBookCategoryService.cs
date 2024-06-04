using Application.DTOs;

namespace Application.Contracts
{
    public interface IBookCategoryService
    {
        Task<List<BookDto>> GetBooksByCategory(Guid categoryId);
        Task<List<CategoryDto>> GetCategoriesByBook(Guid bookId);
        Task Add(Guid bookId, List<Guid> categoryIds);
        Task RemoveByCategory(Guid categoryId);
        Task RemoveByBook(Guid bookId);
    }
}