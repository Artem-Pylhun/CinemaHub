using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaHub.Domain.Entities.Common;

namespace CinemaHub.Domain.Entities
{
    public class Review : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Range(0, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double Rating { get; set; }
        public string Comment { get; set; }
        public virtual Movie? Movie { get; set; }
        [ForeignKey(nameof(Movie))]
        public Guid? MovieId { get; set; }
        public virtual User? User { get; set; }
        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }
    }
}
