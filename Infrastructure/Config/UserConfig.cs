using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Hash password before save to database
            int costFactor = 10;
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword("Admin123!", costFactor);
            builder.HasData(
                new User()
                {
                    UserId = Guid.Parse("79d3b7be-c7e7-4efc-befd-0c6c09cc9a8b"),
                    Username = "admin",
                    Password = hashedPassword,
                    FullName = "tlong",
                    Email = "thanhlongvu156@gmail.com",
                    Phone = "0987654321",
                    Address = "Hanoi",
                    Role = UserRole.Admin,
                    AvatarUrl = "admin.png"
                }
            );
        }
    }
}