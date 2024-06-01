using CinemaHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Infrastructure.DTOs
{
    public class HallDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int RowsNumber { get; set; }
        public int ColumnsNumber { get; set; }
        public Guid? ScreenSizeId { get; set; }
        public Guid? CinemaId { get; set; }
    }
    public class HallCreateDto
    {
        public string Title { get; set; }
        public int RowsNumber { get; set; }
        public int ColumnsNumber { get; set; }
        public Guid? ScreenSizeId { get; set; }
        public Guid? CinemaId { get; set; }
        public ICollection<int> VipRows { get; set; }
    }
    public class HallUpdateDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public int RowsNumber { get; set; }
        public int ColumnsNumber { get; set; }
        public Guid? ScreenSizeId { get; set; }
        public Guid? CinemaId { get; set; }
        public ICollection<int> VipRows { get; set; }
    }
}
