using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("Books")]
    public class Book
    {
        // Properties
        [Key]
        public Guid BookId { get; set; }
        [StringLength(255)]
        public required string Title { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public required string Author { get; set; }
        public required string Publisher { get; set; }
        public string CoverUrl { get; set; } = "default_book.png";

        // Foreign Keys

        // Relationships
        public virtual ICollection<BookCategory>? BookCategories { get; set; }
        public virtual ICollection<RequestDetail>? RequestDetails { get; set; }
    }
}