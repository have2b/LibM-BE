using Application.Contracts;
using Application.DTOs;
using Application.Utils;
using Core.Contracts;
using Core.Entities;
using Mapster;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;

        public UserService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var user = await EntityHelper
                            .GetEntityAndCheckIfItExists
                            (
                                userId,
                                _repository.User.GetUserAsync
                            );
            _repository.User.DeleteUser(user);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _repository.User.GetAllUsersAsync();

            var usersDto = users.Adapt<IEnumerable<UserDto>>();

            return usersDto;
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await EntityHelper
                            .GetEntityAndCheckIfItExists
                            (
                                id,
                                _repository.User.GetUserAsync
                            );

            return user.Adapt<UserDto>();
        }

        public async Task UpdateUserAsync(Guid userId, UserDto model)
        {
            var user = await EntityHelper
                            .GetEntityAndCheckIfItExists
                            (
                                userId,
                                _repository.User.GetUserAsync
                            );

            model.Adapt(user);
            await _repository.SaveAsync();
        }

        public async Task<UserDto> GetUserByTokenAsync(string username)
        {
            // Check exist in database by username
            var user = await _repository.User.GetUserByUsernameAsync(username) ?? throw new Exception("User not found");

            return user.Adapt<UserDto>();
        }
    }
}