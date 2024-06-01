using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Domain
{
    public static class DaysOfWeekTitles
    {
        public static Dictionary<int, string> EnglishTitles = new Dictionary<int, string>()
        {
            { 0, "Sun" },
            { 1, "Mon" },
            { 2, "Tue" },
            { 3, "Wed" },
            { 4, "Thu" },
            { 5, "Fri" },
            { 6, "Sat" }
        };
    }
}
