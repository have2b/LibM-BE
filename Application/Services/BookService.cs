using Application.Contracts;
using Application.DTOs;
using Application.Utils;
using Core.Contracts;
using Core.Entities;
using Mapster;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IRepositoryManager _repository;

        public BookService(IRepositoryManager repository)
        {
            _repository = repository;
        }
        public async Task<BookDto> CreateBookAsync(BookDto model)
        {
            var bookEntity = model.Adapt<Book>();

            _repository.Book.CreateBook(bookEntity);
            await _repository.SaveAsync();

            return bookEntity.Adapt<BookDto>();
        }

        public async Task DeleteBookAsync(Guid bookId)
        {
            var book = await EntityHelper
                            .GetEntityAndCheckIfItExists
                            (
                                bookId,
                                _repository.Book.GetBookAsync
                            );
            _repository.Book.DeleteBook(book);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = await _repository.Book.GetAllBooksAsync();

            var booksDto = books.Adapt<IEnumerable<BookDto>>();

            return booksDto;
        }

        public async Task<BookDto> GetBookByIdAsync(Guid id)
        {
            var book = await EntityHelper
                            .GetEntityAndCheckIfItExists
                            (
                                id,
                                _repository.Book.GetBookAsync
                            );

            return book.Adapt<BookDto>();
        }

        public async Task UpdateBookAsync(Guid bookId, BookDto model)
        {
            var book = await EntityHelper
                            .GetEntityAndCheckIfItExists
                            (
                                bookId,
                                _repository.Book.GetBookAsync
                            );

            model.Adapt(book);
            await _repository.SaveAsync();
        }
    }
}