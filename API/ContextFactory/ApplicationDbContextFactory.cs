using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API.ContextFactory
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseNpgsql(config.GetConnectionString("Default"),
            b => b.MigrationsAssembly("API"));

            return new ApplicationDbContext(builder.Options);
        }
    }
}