using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CinemaHub.Domain.Entities.Common;
using Microsoft.AspNetCore.Http;

namespace CinemaHub.Domain.Entities
{
    public class Director:IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string ImagePath { get; set; } = "/img/no_photo.jpg";
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        [JsonIgnore]
        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();

    }
}
