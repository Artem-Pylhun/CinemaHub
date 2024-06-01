using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Infrastructure.DTOs
{
    public class GenreDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
    public class GenreCreateDto
    {
        public string Title { get; set; }

    }
    public class GenreUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
