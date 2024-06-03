using CinemaHub.Domain.Context;
using CinemaHub.Domain.Entities;
using CinemaHub.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CinemaHub.Repositories.Movies
{
    public class MovieRepository : IMovieRepository
    {
        protected CinemaContext _ctx;
        public MovieRepository(CinemaContext ctx)
        {
            _ctx = ctx;
        }
        public async Task CreateAsync(Movie entity)
        {
            await _ctx.Movies.AddAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            _ctx.Movies.Remove(await _ctx.Movies.FindAsync(id));
            await SaveAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _ctx.Movies.ToListAsync();
        }

        public async Task<Movie> GetAsync(Guid id)
        {
            return await _ctx.Movies.FindAsync(id);
        }

        public async Task<Movie> GetMovieAsyncWithIncludes(Guid id)
        {
            return _ctx.Movies.Include(m => m.Genres)
                .Include(m => m.Actors)
                .Include(m => m.Directors)
                .First(m => m.Id == id);
        }

        public async Task SaveAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie entity)
        {
            _ctx.Movies.Update(entity);
            await SaveAsync();
        }
    }
}
