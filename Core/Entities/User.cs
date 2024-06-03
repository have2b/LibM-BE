using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class User
    {
        // Properties
        [Key]
        public Guid UserId { get; set; }
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

        // Foreign Keys

        // Relationships
        public virtual ICollection<Request>? Requests { get; set; }
    }

    public enum UserRole
    {
        Admin = 0,
        User = 1
    }
}