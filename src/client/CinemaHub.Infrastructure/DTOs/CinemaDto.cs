using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Infrastructure.DTOs
{
    public class CinemaDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class CinemaCreateDto
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class CinemaUpdateDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
    }
}
