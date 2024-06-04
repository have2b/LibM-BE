using Application.Contracts;
using Application.DTOs;
using Application.Utils;
using Core.Contracts;
using Core.Entities;
using Mapster;

namespace Application.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepositoryManager _repository;

        public RequestService(IRepositoryManager repository)
        {
            _repository = repository;
        }
        public async Task<RequestDto> CreateRequestAsync(RequestDto model)
        {
            var requestEntity = model.Adapt<Request>();

            _repository.Request.CreateRequest(requestEntity);
            await _repository.SaveAsync();

            return requestEntity.Adapt<RequestDto>();
        }

        public async Task DeleteRequestAsync(Guid requestId)
        {
            var request = await EntityHelper
                            .GetEntityAndCheckIfItExists
                            (
                                requestId,
                                _repository.Request.GetRequestAsync
                            );
            _repository.Request.DeleteRequest(request);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<RequestDto>> GetRequestsAsync()
        {
            var requests = await _repository.Request.GetAllRequestsAsync();

            var requestsDto = requests.Adapt<IEnumerable<RequestDto>>();

            return requestsDto;
        }

        public async Task<RequestDto> GetRequestByIdAsync(Guid id)
        {
            var request = await EntityHelper
                            .GetEntityAndCheckIfItExists
                            (
                                id,
                                _repository.Request.GetRequestAsync
                            );

            return request.Adapt<RequestDto>();
        }

        public async Task UpdateRequestAsync(Guid requestId, RequestDto model)
        {
            var request = await EntityHelper
                            .GetEntityAndCheckIfItExists
                            (
                                requestId,
                                _repository.Request.GetRequestAsync
                            );

            model.Adapt(request);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<RequestDto>> GetRequestsForForRequestorAsync(Guid requestorId)
        {
            var requests = await _repository.Request.GetRequestsByRequestor(requestorId);

            return requests.Adapt<IEnumerable<RequestDto>>();
        }
    }
}