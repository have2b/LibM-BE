using Core.Entities;

namespace Core.Contracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookAsync(Guid bookId);
        void CreateBook(Book book);
        void DeleteBook(Book book);
    }
}