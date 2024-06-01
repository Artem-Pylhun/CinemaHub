using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Infrastructure.DTOs
{
    public class MovieDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Release { get; set; }
        public string PosterUrl { get; set; }
        public int? MinAge { get; set; }
        public int? Duration { get; set; }
    }

    public class MovieCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Release { get; set; }
        public string PosterUrl { get; set; }
        public int? MinAge { get; set; }
        public int? Duration { get; set; }
        public ICollection<Guid> GenresIds { get; set; }
        public ICollection<Guid> ActorsIds { get; set; }
        public ICollection<Guid> DirectorsIds { get; set; }
    }

    public class MovieUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Release { get; set; }
        public string PosterUrl { get; set; }
        public int? MinAge { get; set; }
        public int? Duration { get; set; }
        public ICollection<Guid> GenresIds { get; set; }
        public ICollection<Guid> ActorsIds { get; set; }
        public ICollection<Guid> DirectorsIds { get; set; }
    }
}
