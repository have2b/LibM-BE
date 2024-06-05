using Application.DTOs;

namespace Application.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<UserDto> GetUserByTokenAsync(string token);
        Task UpdateUserAsync(Guid userId, UserDto model);
        Task DeleteUserAsync(Guid userId);
    }
}