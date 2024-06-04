using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public record CategoryDto
    {
        public Guid CategoryId { get; init; }
        [StringLength(255)]
        public required string CategoryName { get; init; }
        [StringLength(500)]
        public required string Description { get; init; }
    }
}