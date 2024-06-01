using CinemaHub.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Domain.Context
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            var (aID, uID) = _seedRoles(builder);
            _seedRoles(builder);
            _seedAdmins(builder, aID);
        }

        private static (Guid, Guid) _seedRoles(ModelBuilder builder)
        {
            var ADMIN_ROLE_ID = Guid.NewGuid();
            var USER_ROLE_ID = Guid.NewGuid();

            builder.Entity<IdentityRole<Guid>>()
                .HasData(
                new IdentityRole<Guid>
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = ADMIN_ROLE_ID.ToString()
                },
                new IdentityRole<Guid>
                {
                    Id = USER_ROLE_ID,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = USER_ROLE_ID.ToString(),
                }
                );
            return (ADMIN_ROLE_ID, USER_ROLE_ID);
        }

        private static Guid _seedAdmins(ModelBuilder builder, Guid ADMIN_ROLE_ID)
        {
            var adminId = Guid.NewGuid();

            var admin = new User
            {
                Id = adminId,
                UserName = "admin@gmail.com",
                DateOfBirth = DateTime.Now,
                EmailConfirmed = true,
                NormalizedUserName = "admin@gmail.com".ToUpper(),
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "Артем",
                LastName = "Пильгун"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin$23");

            builder.Entity<User>()
                .HasData(admin);

            builder.Entity<IdentityUserRole<Guid>>()
              .HasData(
                  new IdentityUserRole<Guid>
                  {
                      RoleId = ADMIN_ROLE_ID,
                      UserId = adminId
                  }
              );

            return adminId;
        }
    }
}
