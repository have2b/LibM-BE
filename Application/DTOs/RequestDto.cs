using Core.Entities;

namespace Application.DTOs
{
    public record RequestDto
    {
        public Guid RequestId { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Waiting;
        public required Guid RequestorId { get; set; }
        public required Guid ApproverId { get; set; }
        public List<Guid>? BookIds { get; set; }
    }
}