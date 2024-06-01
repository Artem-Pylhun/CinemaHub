using CinemaHub.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Domain.Entities
{
    public class Seat : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Row {  get; set; }
        public int Column { get; set; }
        public int Number { get; set; }
        public bool IsVIP { get; set; }
        public virtual Hall? Hall { get; set; }
        [ForeignKey(nameof(Hall))]
        public Guid? HallId { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
