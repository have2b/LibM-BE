using Core.Entities;

namespace Core.Contracts
{
    public interface IRequestDetailRepository
    {
        Task<List<Book>> GetBooksByRequest(Guid requestId);
        void Add(Guid requestId, List<Guid> bookIds);
    }
}