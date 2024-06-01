using CinemaHub.Domain.Context;
using CinemaHub.Domain.Entities;
using CinemaHub.Domain.Entities.Common;
using CinemaHub.Repositories.Common;
using CinemaHub.Repositories.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Repositories.Users
{
    public class UserRoleRepository : Repository<User, Guid>, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public UserRoleRepository(CinemaContext ctx,
            UserManager<User> userManager,
            RoleManager<IdentityRole<Guid>> roleManager) : base(ctx)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<User> CreateWithPasswordAsync(AppUserCreateModel model)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = (DateTime)model.DateOfBirth,
                EmailConfirmed = false,
                NormalizedUserName = model.Email.ToUpper(),
                Email = model.Email
            };

            await _userManager.CreateAsync(newUser, model.Password);
            await _userManager.AddToRoleAsync(newUser, "User");
            return await _ctx.Users.FirstAsync(x => x.Email == model.Email);
        }
        public async Task<IEnumerable<IdentityRole<Guid>>> GetRolesAsync()
        {
            return await _ctx.Roles.ToListAsync();
        }

        public async Task<int> IsConfirmed(Guid id)
        {
            return (await _ctx.Users.FirstAsync(x => x.Id == id)).EmailConfirmed ? 1 : 0;
        }

        public async Task UpdateUserAsync(AppUserViewModel model, string[] roles)
        {
            var user = _ctx.Users.Find(model.Id);

            if (user.Email != model.Email)
            {
                user.Email = model.Email;
                user.UserName = model.Email;
                user.NormalizedEmail = model.Email.ToUpper();
            }

            if (user.FirstName != model.FirstName)
                user.FirstName = model.FirstName;

            if (user.LastName != model.LastName)
                user.LastName = model.LastName;
            if (user.DateOfBirth != model.DateOfBirth)
                user.DateOfBirth = (DateTime)model.DateOfBirth;

            if (user.EmailConfirmed != model.IsEmailConfirmed)
                user.EmailConfirmed = model.IsEmailConfirmed;

            var admRole = await _roleManager.FindByNameAsync("Admin");

            if ((await _userManager.GetRolesAsync(user)).Any())
            {
                await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
            }

            if (roles.Any())
            {
                await _userManager.AddToRolesAsync(user, roles.ToList());
            }
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteUser(Guid id)
        {
            var user = _ctx.Users.Find(id);

            if (await CheckUser(id))
            {
                if ((await _userManager.GetRolesAsync(user)).Any())
                {
                    await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
                }

                await _userManager.DeleteAsync(user);
            }
        }

        public async Task<IEnumerable<AppUserViewModel>> GetAllWithRolesAsync()
        {
            var list = new List<AppUserViewModel>();

            foreach (var user in await _ctx.Users.ToListAsync())
                list.Add(await GetOneWithRolesAsync(user.Id));

            return list;
        }

        public async Task<AppUserViewModel> GetOneWithRolesAsync(Guid id)
        {
            var user = await _ctx.Users.FirstAsync(x => x.Id == id);
            var userModel = new AppUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                IsEmailConfirmed = user.EmailConfirmed,
                Roles = new List<IdentityRole<Guid>>()
            };

            foreach (var role in await _userManager.GetRolesAsync(user))
            {
                userModel.Roles.Add(await _ctx.Roles.FirstAsync(x => x.Name.ToLower() == role.ToLower()));
            }

            return userModel;
        }
        public async Task<bool> CheckUser(Guid id)
        {
            var user = _ctx.Users.Find(id);
            var roles = await _userManager.GetRolesAsync(user);
            return roles.All(x => x != "Admin");
        }

    }
}
