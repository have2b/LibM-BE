using Application.Contracts;
using Application.DTOs;
using Core.Contracts;
using Core.Entities;
using Mapster;

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
        public async Task<string> LoginAsync(LoginRequest request)
        {
            // Check exist in database
            var user = await _repository.User.GetUserByUsernameAsync(request.Username) ?? throw new Exception("User not found");

            // Check correct password
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password)) throw new Exception("Incorrect password");

            // If exist, so gen token
            return _jwtAuthService.GenerateToken(user);
        }

        public async Task<bool> RegisterAsync(UserDto model)
        {
            // Check exist in database by username
            var user = await _repository.User.GetUserByUsernameAsync(model.Username);
            if (user is not null) throw new Exception("Username already exists");

            // Hash password before save to database
            int costFactor = 10;
            model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password, costFactor);
            // Create new user
            _repository.User.Register(model.Adapt<User>());
            await _repository.SaveAsync();

            return true;
        }
    }
}