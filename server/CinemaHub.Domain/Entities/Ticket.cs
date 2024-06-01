using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaHub.Domain.Entities.Common;

namespace CinemaHub.Domain.Entities
{
    public class Ticket : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public virtual Seat? Seat { get; set; }
        [ForeignKey(nameof(Seat))]
        public Guid? SeatId { get; set; }
        public virtual User? User { get; set; }
        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }
        public virtual Screening? Screening { get; set; }
        [ForeignKey(nameof(Screening))]
        public Guid? ScreeningId { get; set; }
    }
}
