using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using backend.Data;
using backend.Dtos.User;
using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;
        public UserRepository(ApplicationContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<User?> CreateUserAsync(User user, string password, string role)
        {
            try
            {
                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    Console.WriteLine(result.Errors);
                    return null;
                }
                result = await _userManager.AddToRoleAsync(user, role);
                if (!result.Succeeded)
                {
                    Console.WriteLine(result.Errors);
                    return null;
                }
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<User?> DeleteUserAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null) return null;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(s => s.Subscriptions).ToListAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }


        public async Task<User?> GetUserByIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> UpdateUserAsync(string id, UpdateUserRequestDto updateUserRequestDto)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null) return null;

            if (!string.IsNullOrWhiteSpace(updateUserRequestDto.Password))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, token, updateUserRequestDto.Password);
            }

            var currentRole = (await _userManager.GetRolesAsync(user)).First();
            if (currentRole != updateUserRequestDto.Role)
            {
                await _userManager.RemoveFromRoleAsync(user, currentRole);
                await _userManager.AddToRoleAsync(user, updateUserRequestDto.Role);
            }

            user.FirstName = updateUserRequestDto.FirstName;
            user.LastName = updateUserRequestDto.LastName;
            user.Email = updateUserRequestDto.Email;
            user.UserName = updateUserRequestDto.UserName;
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return user;
        }

        public bool CheckUserExist(string id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        public bool CheckUserNameExist(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public bool CheckUserExistByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public async Task<User?> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<HttpStatusCode> ValidateEmail(string newEmail, string userId)
        {
            var existingEmailUser = await _userManager.FindByEmailAsync(newEmail);
            if (existingEmailUser != null && existingEmailUser.Id != userId)
            {
                return HttpStatusCode.Conflict;
            }

            return HttpStatusCode.OK;
        }

        public async Task<HttpStatusCode> ValidateUserName(string newUsername, string userId)
        {
            var existingUsernameUser = await _userManager.FindByNameAsync(newUsername);
            if (existingUsernameUser != null && existingUsernameUser.Id != userId)
            {
                return HttpStatusCode.Conflict;
            }

            return HttpStatusCode.OK;
        }
    }
}