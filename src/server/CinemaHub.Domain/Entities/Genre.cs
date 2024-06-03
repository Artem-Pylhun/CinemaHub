using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CinemaHub.Domain.Entities.Common;

namespace CinemaHub.Domain.Entities
{
    public class Genre : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        [JsonIgnore]
        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();

    }
}
