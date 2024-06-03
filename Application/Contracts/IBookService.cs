using Application.DTOs;

namespace Application.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksAsync();
        Task<BookDto> GetBookByIdAsync(Guid id);
        Task<BookDto> CreateBookAsync(BookDto model);
        Task UpdateBookAsync(Guid bookId, BookDto model);
        Task DeleteBookAsync(Guid bookId);
    }
}