using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaHub.Domain.Entities.Common;

namespace CinemaHub.Domain.Entities
{
    public class Cinema: IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Hall> Halls { get; set; } = new HashSet<Hall>();
    }
}
