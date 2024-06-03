using AutoMapper;
using CinemaHub.Domain.Entities;
using CinemaHub.Infrastructure.DTOs;
using CinemaHub.Repositories.Common;
using CinemaHub.Repositories.Movies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CinemaHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IRepository<Genre, Guid> _genreRepository;
        private readonly IRepository<Actor, Guid> _actorRepository;
        private readonly IRepository<Director, Guid> _directorRepository;
        private readonly IRepository<Screening, Guid> _screeningRepository;
        private readonly IMapper _mapper;

        public MovieController(IMovieRepository movieRepository, IRepository<Genre, Guid> genreRepository, IRepository<Actor, Guid> actorRepository, IRepository<Director, Guid> directorRepository, IRepository<Screening, Guid> screeningRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _actorRepository = actorRepository;
            _directorRepository = directorRepository;
            _screeningRepository = screeningRepository;
            _mapper = mapper;
        }
        
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieRepository.GetAllAsync();
            return Ok(movies);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Movie>> AddMovie(MovieCreateDto movie)
        {
            if (movie == null)
            {
                return BadRequest("Movie wasn't found");
            }
            var newMovie = _mapper.Map<Movie>(movie);
            var genres = (await _genreRepository.GetAllAsync()).Where(g => movie.GenresIds.Contains(g.Id));
            var actors = (await _actorRepository.GetAllAsync()).Where(a => movie.ActorsIds.Contains(a.Id));
            var directors = (await _directorRepository.GetAllAsync()).Where(d => movie.DirectorsIds.Contains(d.Id));
            newMovie.Actors = actors.ToList();
            newMovie.Directors = directors.ToList();
            newMovie.Genres = genres.ToList();

            await _movieRepository.CreateAsync(newMovie);
            return Ok(movie);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(Guid id)
        {
            var movie = await _movieRepository.GetMovieAsyncWithIncludes(id);
            if (movie is null)
            {
                return NotFound("Movie not found");
            }
            return Ok(movie);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteMovie(Guid id)
        {
            var movie = await _movieRepository.GetAsync(id);
            if (movie == null)
            {
                return NotFound("Movie not found");
            }
            var screenings = (await _screeningRepository.GetAllAsync()).Where(s => s.MovieId == id).ToList();
            for (int i = 0; i < screenings.Count(); i++)
            {
                await _screeningRepository.DeleteAsync(screenings[i].Id);
            }
            await _movieRepository.DeleteAsync(id);
            return Ok(movie);
        }


        [HttpPut("update")]
        public async Task<ActionResult<Movie>> UpdateMovie(MovieUpdateDto movieDto)
        {
            if (movieDto == null)
            {
                return BadRequest("Movie not found");
            }

            var existingMovie = await _movieRepository.GetMovieAsyncWithIncludes(movieDto.Id);
            if (existingMovie == null)
            {
                return NotFound("Movie not found");
            }

            // Update basic fields
            existingMovie.Title = movieDto.Title;
            existingMovie.Description = movieDto.Description;
            existingMovie.Release = movieDto.Release;
            existingMovie.PosterUrl = movieDto.PosterUrl;
            existingMovie.MinAge = movieDto.MinAge;
            existingMovie.Duration = movieDto.Duration;

            // Update relationships
            existingMovie.Actors = (await _actorRepository.GetAllAsync()).Where(a => movieDto.ActorsIds.Contains(a.Id)).ToList();
            existingMovie.Directors = (await _directorRepository.GetAllAsync()).Where(d => movieDto.DirectorsIds.Contains(d.Id)).ToList();
            existingMovie.Genres = (await _genreRepository.GetAllAsync()).Where(g => movieDto.GenresIds.Contains(g.Id)).ToList();

            await _movieRepository.UpdateAsync(existingMovie);
            return Ok(existingMovie);
        }
    }
}
