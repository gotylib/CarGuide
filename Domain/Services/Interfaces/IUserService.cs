using API.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IUserService
    {
        // Получение всех пользователей
        Task<IEnumerable<User>> GetAllUsersAsync();

        // Получение пользователя по имени
        Task<User> GetUserByNameAsync(string name);

        // Добавление нового пользователя
        Task AddUserAsync(User user);

        // Обновление существующего пользователя
        Task UpdateUserAsync(User user);

        // Удаление пользователя
        Task DeleteUserAsync(string name);

        Task<IActionResult> Register(RegisterDto model);
        Task<IActionResult> Login(LoginDto model);
        Task<IActionResult> RefreshToken(RefreshTokenDto model);
    }
}
