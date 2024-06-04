using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public record LoginRequest
    {
        [StringLength(255)]
        public required string Username { get; init; }
        [StringLength(255)]
        public required string Password { get; init; }
    }
}