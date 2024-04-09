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
                user = new User { UserName = "admin", Email = "hassanhmd1734@gmail.com", FirstName = "Hassan", LastName = "Hammoud", Role = "Admin", Gender = "Male", Country = "Lebanon" };
                await userManager.CreateAsync(user, "Admin123@");
                await userManager.AddToRoleAsync(user, user.Role);

                for (var i = 0; i < 15; i++)
                {
                    user = new User
                    {
                        UserName = Faker.Internet.UserName(),
                        Email = Faker.Internet.Email(user.UserName),
                        FirstName = Faker.Name.First(),
                        LastName = Faker.Name.Last(),
                        Role = "User",
                        Gender = Faker.RandomNumber.Next(0, 1) == 1 ? "Male" : "Female",
                        Country = Faker.Address.Country()
                    };
                    await userManager.CreateAsync(user, "User123@");
                    await userManager.AddToRoleAsync(user, user.Role);
                }
            }
        }
        private enum Gender
        {
            Male,
            Female
        }
    }
}