using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Infrastructure.DTOs
{
    public class ActorDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
    public class ActorCreateDto
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string? ImagePath { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
    public class ActorUpdateDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string? ImagePath { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
