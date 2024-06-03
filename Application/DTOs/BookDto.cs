using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public record BookDto
    {
        [StringLength(255)]
        public required string Title { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public required string Author { get; set; }
        public required string Publisher { get; set; }
        public string CoverUrl { get; set; } = "default_book.png";
    }
}