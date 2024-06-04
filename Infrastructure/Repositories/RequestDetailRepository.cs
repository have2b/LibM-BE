using Core.Contracts;
using Core.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RequestDetailRepository(ApplicationDbContext context) : RepositoryBase<RequestDetail>(context), IRequestDetailRepository
    {
        public void Add(Guid requestId, List<Guid> bookIds)
        {
            foreach (var bookId in bookIds)
            {
                Create(new RequestDetail { RequestId = requestId, BookId = bookId });
            }
        }

        public async Task<List<Book>> GetBooksByRequest(Guid requestId)
        {
            var requestDetails = GetAll();
            return await requestDetails
                        .Where(rd => rd.RequestId == requestId)
                        .Select(rd => rd.Book)
                        .ToListAsync();
        }
    }
}