using CinemaHub.Domain.Entities;
using CinemaHub.Repositories.Common;
using CinemaHub.Repositories.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Repositories
{
    public static class DependencyInjectionRepositories
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUserRepository, UserRoleRepository>();
            services.AddScoped<UserManager<User>>();
            services.AddScoped<RoleManager<IdentityRole<Guid>>>();
        }
    }
}
