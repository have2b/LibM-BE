using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("BookCategories")]
    public class BookCategory
    {
        // Properties

        // Foreign Keys
        [ForeignKey("BookId")]
        public Guid BookId { get; set; }
        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }

        // Relationships
        public virtual Book? Book { get; set; }
        public virtual Category? Category { get; set; }
    }
}