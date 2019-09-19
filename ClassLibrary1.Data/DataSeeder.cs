using ClassLibrary1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ClassLibrary1.Data
{
    public class DataSeeder
    {
        private ApplicationDbContext _context;

        public DataSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task SeedSuperUser()
        {
            var roleStore = new RoleStore<IdentityRole>(_context);
            var userStore = new UserStore<ApplicationUser>(_context);
            var hasAdminRole = _context.Roles.Any(roles => roles.Name == "Admin");

            var user = new ApplicationUser
            {
                UserName = "ForumAdmin",
                NormalizedUserName = "FORUMADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var hasher = new PasswordHasher<ApplicationUser>();
            var hashedPassword = hasher.HashPassword(user, "admin");
            user.PasswordHash = hashedPassword;

            if (!hasAdminRole)
            {
                roleStore.CreateAsync(new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });
            }

            var hasSuperUser =
                _context.Users.Any(u => u.NormalizedUserName == user.UserName);

            if (!hasSuperUser)
            {
                userStore.CreateAsync(user);
                userStore.AddToRoleAsync(user, "Admin");
            }

            _context.SaveChangesAsync();

            return Task.CompletedTask;
        }
    }
}
