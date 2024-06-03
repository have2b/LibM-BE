using Core.Contracts;
using Core.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookRepository(ApplicationDbContext context) : RepositoryBase<Book>(context), IBookRepository
    {
        public void CreateBook(Book book) => Create(book);

        public void DeleteBook(Book book) => Delete(book);
        public async Task<IEnumerable<Book>> GetAllBooksAsync() => await GetAll().ToListAsync();

        public async Task<Book> GetBookAsync(Guid bookId)
        => await GetByCondition(b => b.BookId.Equals(bookId)).FirstOrDefaultAsync();
    }
}