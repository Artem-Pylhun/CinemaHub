using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaHub.Domain.Entities.Common;

namespace CinemaHub.Domain.Entities
{
    public class Hall: IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public int RowsNumber { get; set; }
        public int ColumnsNumber { get; set; }
        public virtual ScreenSize? ScreenSize { get; set; }
        [ForeignKey(nameof(ScreenSize))]
        public Guid? ScreenSizeId { get; set; }
        public virtual Cinema? Cinema { get; set; }
        [ForeignKey(nameof(Cinema))]
        public Guid? CinemaId { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; } = new HashSet<Screening>();
        public virtual ICollection<Seat> Seats { get; set; } = new HashSet<Seat>();
    }
}
