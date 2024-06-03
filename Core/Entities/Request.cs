using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("Requests")]
    public class Request
    {
        // Properties
        [Key]
        public Guid RequestId { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public BookBorrowingRequestStatus Status { get; set; } = BookBorrowingRequestStatus.Waiting;

        // Foreign Keys
        [ForeignKey("UserId")]
        public required Guid RequestorId { get; set; }
        [ForeignKey("UserId")]
        public required Guid ApproverId { get; set; }

        // Relationships
        public virtual User? Requestor { get; set; }
        public virtual User? Approver { get; set; }
        public ICollection<RequestDetail>? RequestDetails { get; set; }
    }

    public enum BookBorrowingRequestStatus
    {
        Approved = 0,
        Rejected = 1,
        Waiting = 2
    }
}