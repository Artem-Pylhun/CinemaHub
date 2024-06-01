using CinemaHub.Domain.Entities;
using CinemaHub.Repositories.Common;
using CinemaHub.Repositories.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Repositories.Users
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<IEnumerable<AppUserViewModel>> GetAllWithRolesAsync();
        Task<User> CreateWithPasswordAsync(AppUserCreateModel model);
        Task<IEnumerable<IdentityRole<Guid>>> GetRolesAsync();
        Task<AppUserViewModel> GetOneWithRolesAsync(Guid id);
        Task UpdateUserAsync(AppUserViewModel model, string[] roles);

        Task<bool> CheckUser(Guid id);
        Task DeleteUser(Guid id);
    }
}
