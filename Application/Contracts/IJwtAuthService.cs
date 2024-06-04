using Core.Entities;

namespace Application.Contracts
{
    public interface IJwtAuthService
    {
        string GenerateToken(User user);
    }
}