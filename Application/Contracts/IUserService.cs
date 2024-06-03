using Application.DTOs;

namespace Application.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<UserDto> CreateUserAsync(UserDto model);
        Task UpdateUserAsync(Guid userId, UserDto model);
        Task DeleteUserAsync(Guid userId);
    }
}