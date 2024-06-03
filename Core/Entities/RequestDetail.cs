using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("BookBorrowingRequestDetails")]
    public class RequestDetail
    {
        // Properties

        // Foreign Keys
        [ForeignKey("BookBorrowingRequestId")]
        public Guid BookBorrowingRequestId { get; set; }
        [ForeignKey("BookId")]
        public Guid BookId { get; set; }

        // Relationships
        public virtual Request? Request { get; set; }
        public virtual Book? Book { get; set; }
    }
}