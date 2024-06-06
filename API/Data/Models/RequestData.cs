using Core.Entities;

namespace API.Data.Models
{
    public record RequestData
    {
        public Guid RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus Status { get; set; }
    }
}