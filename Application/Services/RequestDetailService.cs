using Application.Contracts;
using Application.DTOs;
using Core.Contracts;
using Mapster;

namespace Application.Services
{
    public class RequestDetailService : IRequestDetailService
    {
        private readonly IRepositoryManager _repository;

        public RequestDetailService(IRepositoryManager repository)
        {
            _repository = repository;
        }
        public Task Add(Guid requestId, List<Guid> bookIds)
        {
            _repository.RequestDetail.Add(requestId, bookIds);

            return Task.CompletedTask;
        }

        public async Task<List<BookDto>> GetBooksByRequest(Guid requestId)
        {
            var books = await _repository.RequestDetail.GetBooksByRequest(requestId);
            return books.Adapt<List<BookDto>>();
        }
    }
}