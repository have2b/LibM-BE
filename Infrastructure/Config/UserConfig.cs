using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User()
                {
                    UserId = Guid.NewGuid(),
                    Username = "admin",
                    Password = "Admin123!",
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