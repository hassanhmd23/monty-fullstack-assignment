using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace backend.Seeders
{
    public class RoleSeeder
    {
        public static async Task Initialize(RoleManager<IdentityRole> roleManager)
        {
            var roleExists = await roleManager.FindByNameAsync("Admin");
            if (roleExists == null)
            {
                List<IdentityRole> roles = new()
            {
                new() {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new() {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(role);
                }
            }
        }
    }
}