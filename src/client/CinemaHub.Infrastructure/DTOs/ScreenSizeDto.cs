using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Infrastructure.DTOs
{
    public class ScreenSizeDto
    {
        public Guid Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
    public class ScreenSizeCreateDto
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }
    public class ScreenSizeUpdateDto
    {
        public Guid Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
