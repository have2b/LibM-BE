using Application.DTOs;

namespace Application.Contracts
{
    public interface IRequestDetailService
    {
        Task<List<BookDto>> GetBooksByRequest(Guid requestId);
        Task Add(Guid requestId, List<Guid> bookIds);
    }
}