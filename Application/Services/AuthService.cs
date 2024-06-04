using Application.Contracts;
using Application.DTOs;
using Core.Contracts;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepositoryManager _repository;
        private readonly IJwtAuthService _jwtAuthService;

        public AuthService(IRepositoryManager repository, IJwtAuthService jwtAuthService)
        {
            _repository = repository;
            _jwtAuthService = jwtAuthService;
        }
        public async Task<string> Login(LoginRequest request)
        {
            // Check exist in database
            var user = await _repository.User.GetUserByUsernameAsync(request.Username) ?? throw new Exception("User not found");

            // If exist, so gen token
            return _jwtAuthService.GenerateToken(user);
        }
    }
}