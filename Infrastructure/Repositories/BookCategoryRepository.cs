using Core.Contracts;
using Core.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookCategoryRepository(ApplicationDbContext context) : RepositoryBase<BookCategory>(context), IBookCategoryRepository
    {
        public void Add(Guid bookId, List<Guid> categoryIds)
        {
            foreach (var categoryId in categoryIds)
            {
                Create(new BookCategory { BookId = bookId, CategoryId = categoryId });
            }
        }

        public async Task<List<Book?>> GetBooksByCategory(Guid categoryId)
        {
            var bookCategory = GetAll();
            return await bookCategory
                        .Where(bc => bc.CategoryId == categoryId)
                        .Select(bc => bc.Book)
                        .ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesByBook(Guid bookId)
        {
            var bookCategory = GetAll();
            return await bookCategory
                        .Where(bc => bc.BookId == bookId)
                        .Select(bc => bc.Category)
                        .ToListAsync();
        }

        public void RemoveByBook(Guid bookId)
        {
            var bookCategories = GetAll().Where(bc => bc.BookId == bookId);

            foreach (var bookCategory in bookCategories)
            {
                Delete(bookCategory);
            }
        }

        public void RemoveByCategory(Guid categoryId)
        {
            var bookCategories = GetAll().Where(bc => bc.CategoryId == categoryId);

            foreach (var bookCategory in bookCategories)
            {
                Delete(bookCategory);
            }
        }
    }
}