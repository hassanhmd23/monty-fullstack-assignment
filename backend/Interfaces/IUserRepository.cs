using System.Net;
using backend.Dtos.User;
using backend.Models;

namespace backend.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(string id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByUserNameAsync(string userName);
        Task<User?> CreateUserAsync(User user, string password, string role);
        Task<User?> UpdateUserAsync(string id, UpdateUserRequestDto updateUserRequestDto);
        Task<User?> DeleteUserAsync(string id);
        bool CheckUserExist(string id);
        bool CheckUserNameExist(string username);
        bool CheckUserExistByEmail(string id);
        Task<HttpStatusCode> ValidateEmail(string newEmail, string userId);
        Task<HttpStatusCode> ValidateUserName(string newEmail, string userId);
    }
}