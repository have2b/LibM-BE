using Core.Entities;

namespace Core.Contracts
{
    public interface IRequestDetailRepository
    {
        Task<List<Book>> GetBooksByRequest(Guid requestId);
        Task<List<Request>> GetRequestsByBook(Guid bookId);
        void Add(Guid requestId, List<Guid> bookIds);
    }
}