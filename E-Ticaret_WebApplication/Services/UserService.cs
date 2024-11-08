using E_Ticaret_WebApplication.DTOs;
using E_Ticaret_WebApplication.Models;
using E_Ticaret_WebApplication.Repositories.Interfaces;

namespace E_Ticaret_WebApplication.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(a => new UserDto { Id = a.Id, Username = a.Username, Password=a.Password , Email=a.Email});
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return user != null ? new UserDto { Id = user.Id, Username = user.Username, Password = user.Password, Email = user.Email } : null;
        }

        public async Task AddUserAsync(UserDto userDto)
        {
            var user = new User { Username = userDto.Username, Password = userDto.Password, Email = userDto.Email };
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = new User { Id = userDto.Id, Username = userDto.Username, Password = userDto.Password, Email = userDto.Email };
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
