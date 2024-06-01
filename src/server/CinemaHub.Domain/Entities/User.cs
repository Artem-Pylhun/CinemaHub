using CinemaHub.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Domain.Entities
{
    public class User : IdentityUser<Guid>, IEntity<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
