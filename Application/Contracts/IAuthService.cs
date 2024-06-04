using Application.DTOs;

namespace Application.Contracts
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginRequest request);
        Task<bool> RegisterAsync(UserDto model);
    }
}