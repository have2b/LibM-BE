using Core.Entities;

namespace Core.Contracts
{
    public interface IRequestRepository
    {
        Task<IEnumerable<Request>> GetAllBookRequestsAsync();
        Task<Request> GetBookRequestAsync(Guid requestId);
        void CreateBookRequest(Request request);
        void DeleteBookRequest(Request request);
    }
}