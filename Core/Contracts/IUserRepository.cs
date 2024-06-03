using Core.Entities;

namespace Core.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(Guid userId);
        void Register(User user);
        void DeleteUser(User user);
    }
}