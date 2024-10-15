using Domain.Entities;
using Domain.Repositories;
using System;


namespace Domain.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Получение всех пользователей
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        // Получение пользователя по ID
        public async Task<User> GetUserByNameAsync(string name)
        {
            var user = await _userRepository.GetByNameAsync(name);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {name} not found.");
            }
            return user;
        }

        // Добавление нового пользователя
        public async Task AddUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }

            await _userRepository.AddAsync(user);
        }

        // Обновление существующего пользователя
        public async Task UpdateUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }

            var existingUser = await _userRepository.GetByIdAsync(user.);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {user.Id} not found.");
            }

            await _userRepository.UpdateAsync(user);
        }

        // Удаление пользователя
        public async Task DeleteUserAsync(int id)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            await _userRepository.DeleteAsync(id);
        }
    }

}
