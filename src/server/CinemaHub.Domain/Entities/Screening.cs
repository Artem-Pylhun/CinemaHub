using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaHub.Domain.Entities.Common;

namespace CinemaHub.Domain.Entities
{
    public class Screening : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public float UsualTicketsPrice { get; set; }
        public float VIPTicketsPrice { get; set; }
        public DateTime StartTime { get; set; }
        public bool Is3DCapable { get; set; }
        public virtual Movie? Movie { get; set; }
        [ForeignKey(nameof(Movie))]
        public Guid? MovieId { get; set; }
        public virtual Hall? Hall { get; set; }
        [ForeignKey(nameof(Hall))]
        public Guid? HallId { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
