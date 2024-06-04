using Core.Contracts;
using Core.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : RepositoryBase<User>(context), IUserRepository
    {
        public void DeleteUser(User user) => Delete(user);

        public async Task<IEnumerable<User>> GetAllUsersAsync() => await GetAll().ToListAsync();

        public async Task<User> GetUserAsync(Guid userId)
        => await GetByCondition(u => u.UserId.Equals(userId)).FirstOrDefaultAsync();

        public async Task<User> GetUserByUsernameAsync(string username)
        => await GetByCondition(u => u.Username.Equals(username)).FirstOrDefaultAsync();

        public void Register(User user) => Create(user);
    }
}