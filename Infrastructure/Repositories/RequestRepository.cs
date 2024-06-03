using Core.Contracts;
using Core.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RequestRepository(ApplicationDbContext context) : RepositoryBase<Request>(context), IRequestRepository
    {
        public void CreateBookRequest(Request request) => Create(request);

        public void DeleteBookRequest(Request request) => Delete(request);

        public async Task<IEnumerable<Request>> GetAllBookRequestsAsync()
        => await GetAll().ToListAsync();

        public async Task<Request> GetBookRequestAsync(Guid requestId)
        => await GetByCondition(rq => rq.RequestId.Equals(requestId)).FirstOrDefaultAsync();
    }
}