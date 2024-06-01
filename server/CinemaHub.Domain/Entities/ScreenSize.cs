using CinemaHub.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Domain.Entities
{
    public class ScreenSize : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double Width { get; set; }
        public double Height { get; set; }
        public virtual ICollection<Hall> Halls { get; set; } = new HashSet<Hall>();
    }
}
