using Core.Contracts;
using Core.Entities;
using Core.Entities.RequestFeatures;
using Infrastructure.Context;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookRepository(ApplicationDbContext context) : RepositoryBase<Book>(context), IBookRepository
    {
        public void CreateBook(Book book) => Create(book);

        public void DeleteBook(Book book) => Delete(book);
        public async Task<PagedList<Book>> GetBooksAsync(RequestParameters requestParameters)
        {
            var books = await GetAll()
            .Search(requestParameters.SearchTerm)
            .Sort(requestParameters.OrderBy)
            .ToListAsync();

            return PagedList<Book>.ToPagedList(books, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<Book> GetBookAsync(Guid bookId)
        => await GetByCondition(b => b.BookId.Equals(bookId)).FirstOrDefaultAsync();
    }
}