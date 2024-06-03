using Core.Entities;

namespace Core.Contracts
{
    public interface IRequestRepository
    {
        Task<IEnumerable<Request>> GetAllRequestsAsync();
        Task<Request> GetRequestAsync(Guid requestId);
        void CreateRequest(Request request);
        void DeleteRequest(Request request);
    }
}