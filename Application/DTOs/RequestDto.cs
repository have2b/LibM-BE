using Core.Entities;

namespace Application.DTOs
{
    public record RequestDto
    {
        public Guid RequestId { get; }
        public RequestStatus Status { get; init; }
        public DateTime RequestDate { get; set; }
        public required Guid RequestorId { get; set; }
        public required Guid ApproverId { get; set; }
        public List<Guid> BookIds { get; set; }
    }
}