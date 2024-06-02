using CinemaHub.Domain.Entities.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CinemaHub.Domain.Entities
{
    public class Actor : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
        public string? ImagePath { get; set; } = "/img/no_photo.jpg";
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
