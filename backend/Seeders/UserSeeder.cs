using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Identity;

namespace backend.Seeders
{
    public class UserSeeder
    {
        public static async Task Initialize(UserManager<User> userManager)
        {
            var user = await userManager.FindByNameAsync("admin");
            if (user == null)
            {
                user = new User { UserName = "admin", Email = "admin@admin.com", FirstName = "Admin", LastName = "Admin", Role = "Admin", Gender = "Male", Country = "Lebanon" };
                await userManager.CreateAsync(user, "Admin123@");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}