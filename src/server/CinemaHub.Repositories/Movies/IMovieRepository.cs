using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaHub.Domain.Entities;
using CinemaHub.Repositories.Common;

namespace CinemaHub.Repositories.Movies
{
    public interface IMovieRepository : IRepository<Movie, Guid>
    {
        Task<Movie> GetMovieAsyncWithIncludes(Guid id);
    }
}
