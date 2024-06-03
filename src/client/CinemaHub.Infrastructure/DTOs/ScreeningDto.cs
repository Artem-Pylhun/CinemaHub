using CinemaHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Infrastructure.DTOs
{
    public class ScreeningDto
    {
        public Guid Id { get; set; }
        public float UsualTicketsPrice { get; set; }
        public float VIPTicketsPrice { get; set; }
        public DateTime StartTime { get; set; }
        public bool Is3DCapable { get; set; }
        public Guid? MovieId { get; set; }
        public Guid? HallId { get; set; }
        public string? MovieTitle { get; set; }
        public string? HallTitle { get; set; }
    }
    public class ScreeningCreateDto
    {
        public float UsualTicketsPrice { get; set; }
        public float VIPTicketsPrice { get; set; }
        public DateTime StartTime { get; set; }
        public bool Is3DCapable { get; set; }
        public Guid? MovieId { get; set; }
        public Guid? HallId { get; set; }
    }
    public class ScreeningUpdateDto
    {
        public Guid Id { get; set; }
        public float UsualTicketsPrice { get; set; }
        public float VIPTicketsPrice { get; set; }
        public DateTime StartTime { get; set; }
        public bool Is3DCapable { get; set; }
        public Guid? MovieId { get; set; }
        public Guid? HallId { get; set; }
    }
}
