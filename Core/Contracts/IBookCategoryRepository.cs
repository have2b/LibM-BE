using Core.Entities;

namespace Core.Contracts
{
    public interface IBookCategoryRepository
    {
        Task<List<Book?>> GetBooksByCategory(Guid categoryId);
        Task<List<Category>> GetCategoriesByBook(Guid bookId);
        void Add(Guid bookId, List<Guid> categoryIds);
        void RemoveByCategory(Guid categoryId);
        void RemoveByBook(Guid bookId);
    }
}