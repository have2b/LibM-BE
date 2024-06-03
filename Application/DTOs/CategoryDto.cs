using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public record CategoryDto
    {
        [StringLength(255)]
        public required string CategoryName { get; set; }
        [StringLength(500)]
        public required string Description { get; set; }
    }
}