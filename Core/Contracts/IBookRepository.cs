using Core.Entities;
using Core.Entities.RequestFeatures;

namespace Core.Contracts
{
    public interface IBookRepository
    {
        Task<PagedList<Book>> GetBooksAsync(RequestParameters requestParameters);
        Task<Book> GetBookAsync(Guid bookId);
        void CreateBook(Book book);
        void DeleteBook(Book book);
    }
}