using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaHub.Domain.Entities.Common;

namespace CinemaHub.Domain.Entities
{
    public class Movie : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Release { get; set; }
        public string PosterUrl { get; set; }
        public int? MinAge { get; set; }

        public int? Duration { get; set; }
        public virtual ICollection<Actor> Actors { get; set; } = new HashSet<Actor>();
        public virtual ICollection<Director> Directors { get; set; } = new HashSet<Director>();
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public virtual ICollection<Genre> Genres { get; set; } = new HashSet<Genre>();
        public virtual ICollection<Screening> Screenings { get; set; } = new HashSet<Screening>();
    }
}
