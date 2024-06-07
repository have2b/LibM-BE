using System.Linq.Dynamic.Core;
using Core.Entities;

namespace Infrastructure.Utils
{
    public static class RepositoryBookExtensions
    {
        public static IQueryable<Book> Search(this IQueryable<Book> books, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return books;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return books.Where(b => b.Title.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Book> Sort(this IQueryable<Book> books, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return books.OrderBy(b => b.Title);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Book>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return books.OrderBy(b => b.Title);

            return books.OrderBy(orderQuery);
        }
    }
}