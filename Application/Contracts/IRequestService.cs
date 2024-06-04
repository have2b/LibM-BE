using Application.DTOs;

namespace Application.Contracts
{
    public interface IRequestService
    {
        Task<IEnumerable<RequestDto>> GetRequestsAsync();
        Task<RequestDto> GetRequestByIdAsync(Guid id);
        Task<RequestDto> CreateRequestAsync(RequestDto model);
        Task UpdateRequestAsync(Guid requestId, RequestDto model);
        Task DeleteRequestAsync(Guid requestId);
        Task<IEnumerable<RequestDto>> GetRequestsForForRequestorAsync(Guid requestorId);
    }
}