using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            // List<IdentityRole> roles = new()
            // {
            //     new() {
            //         Name = "Admin",
            //         NormalizedName = "ADMIN"
            //     },
            //     new() {
            //         Name = "User",
            //         NormalizedName = "USER"
            //     }
            // };
            // modelBuilder.Entity<IdentityRole>().HasData(roles);
            // var hasher = new PasswordHasher<User>();
            // var user = new User
            // {
            //     Id = "01554538-afc4-4acc-9ac9-0aef00260a23",
            //     UserName = "admin",
            //     Email = "admin@admin.com",
            //     EmailConfirmed = true,
            // };
            // user.PasswordHash = hasher.HashPassword(user, "Admin123@");
            // var createdUser = modelBuilder.Entity<User>().HasData(user);
        }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}