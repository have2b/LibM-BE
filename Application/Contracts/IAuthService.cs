using Application.DTOs;

namespace Application.Contracts
{
    public interface IAuthService
    {
        Task<string> Login(LoginRequest request);
    }
}