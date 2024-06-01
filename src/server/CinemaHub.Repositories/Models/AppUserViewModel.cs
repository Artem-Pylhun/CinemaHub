using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Repositories.Models
{
    public class AppUserViewModel
    {
        public Guid? Id { get; set; }
        public string? Email { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;
        public List<IdentityRole<Guid>>? Roles { get; set; }
    }
}