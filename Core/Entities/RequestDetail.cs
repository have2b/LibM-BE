using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("RequestDetails")]
    public class RequestDetail
    {
        // Properties

        // Foreign Keys
        [ForeignKey("RequestId")]
        public Guid RequestId { get; set; }
        [ForeignKey("BookId")]
        public Guid BookId { get; set; }

        // Relationships
        public virtual Request? Request { get; set; }
        public virtual Book? Book { get; set; }
    }
}