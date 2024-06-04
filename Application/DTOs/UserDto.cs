using System.ComponentModel.DataAnnotations;

using Core.Entities;

namespace Application.DTOs
{
    public record UserDto
    {
        [StringLength(255)]
        public required string Username { get; set; }
        [StringLength(255)]
        public required string Password { get; set; }
        [StringLength(255)]
        public required string FullName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        [StringLength(255)]
        public required string Address { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public string AvatarUrl { get; set; } = "default_user.png";
    }
}