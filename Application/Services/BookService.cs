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
            var dbookEntity = model.Adapt<Book>();

            _repository.Book.CreateBook(dbookEntity);
            await _repository.SaveAsync();

            return dbookEntity.Adapt<BookDto>();
        }

        public async Task DeleteBookAsync(Guid bookId)
        {
            var dbook = await EntityHelper
                            .GetEntityAndCheckIfItExists
                            (
                                bookId,
                                _repository.Book.GetBookAsync
                            );
            _repository.Book.DeleteBook(dbook);
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
            var dbook = await EntityHelper
                            .GetEntityAndCheckIfItExists
                            (
                                id,
                                _repository.Book.GetBookAsync
                            );

            return dbook.Adapt<BookDto>();
        }

        public async Task UpdateBookAsync(Guid bookId, BookDto model)
        {
            var dbook = await EntityHelper
                            .GetEntityAndCheckIfItExists
                            (
                                bookId,
                                _repository.Book.GetBookAsync
                            );

            model.Adapt(dbook);
            await _repository.SaveAsync();
        }
    }
}