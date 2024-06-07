using Application.DTOs;
using Core.Entities.RequestFeatures;

namespace Application.Contracts
{
    public interface IBookService
    {
        Task<(IEnumerable<BookDto> books, Metadata metadata)> GetBooksAsync(RequestParameters requestParameters);
        Task<BookDto> GetBookByIdAsync(Guid id);
        Task<BookDto> CreateBookAsync(BookDto model);
        Task UpdateBookAsync(Guid bookId, BookDto model);
        Task DeleteBookAsync(Guid bookId);
    }
}