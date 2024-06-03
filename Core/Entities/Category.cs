using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("Categories")]
    public class Category
    {
        // Properties
        [Key]
        public Guid CategoryId { get; set; }
        [StringLength(255)]
        public required string CategoryName { get; set; }
        [StringLength(500)]
        public required string Description { get; set; }

        // Foreign Keys

        // Relationships
        public virtual ICollection<BookCategory>? BookCategories { get; set; }
    }
}