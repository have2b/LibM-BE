using Core.Contracts;
using Core.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RequestRepository(ApplicationDbContext context) : RepositoryBase<Request>(context), IRequestRepository
    {
        public void CreateRequest(Request request)
        {
            request.RequestDate = request.RequestDate.ToUniversalTime();
            Create(request);
        }

        public void DeleteRequest(Request request) => Delete(request);

        public async Task<IEnumerable<Request>> GetAllRequestsAsync()
        => await GetAll().ToListAsync();

        public async Task<Request> GetRequestAsync(Guid requestId)
        => await GetByCondition(rq => rq.RequestId.Equals(requestId)).Include(r => r.RequestDetails).FirstOrDefaultAsync();

        public async Task<List<Request>> GetRequestsByRequestor(Guid requestorId)
        => await GetAll().Where(r => r.RequestorId == requestorId).ToListAsync();

    }
}