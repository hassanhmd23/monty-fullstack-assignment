using backend.Dtos.User;
using backend.Models;

namespace backend.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(User user);
        Task<User?> UpdateUserAsync(int id, UpdateUserRequestDto updateUserRequestDto);
        Task<User?> DeleteUserAsync(int id);
        bool CheckUserExist(int id);
    }
}