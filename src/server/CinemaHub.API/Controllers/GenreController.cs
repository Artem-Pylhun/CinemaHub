using AutoMapper;
using CinemaHub.Domain.Entities;
using CinemaHub.Infrastructure.DTOs;
using CinemaHub.Repositories.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IRepository<Genre, Guid> _genreRepository;
        private readonly IMapper _mapper;
        public GenreController(IRepository<Genre, Guid> genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _genreRepository.GetAllAsync();
            return Ok(genres);
        }
        [HttpPost("add")]
        public async Task<ActionResult<Genre>> AddGenre(GenreCreateDto genre)
        {
            if (genre == null)
            {
                return BadRequest("Genre wasn't found");
            }
            await _genreRepository.CreateAsync(_mapper.Map<Genre>(genre));
            return Ok(genre);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenreById(Guid id)
        {
            var genre = await _genreRepository.GetAsync(id);
            if (genre is null)
                return NotFound("Genre not found");
            return Ok(genre);
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteGenre(Guid id)
        {
            var genre = await _genreRepository.GetAsync(id);
            if (genre is null)
                return NotFound("Genre not found");
            await _genreRepository.DeleteAsync(id);
            return Ok($"Genre {genre.Title} deleted");
        }
        [HttpPut("update")]
        public async Task<ActionResult<Genre>> UpdateGenre(GenreUpdateDto genreDTO)
        {
            var genre = _mapper.Map<Genre>(genreDTO);
            if (genre == null)
            {
                return BadRequest("Genre not found");
            }

            // Retrieve the existing genre from the database
            var existingGenre = await _genreRepository.GetAsync(genre.Id);
            if (existingGenre == null)
            {
                return NotFound("Genre not found");
            }

            // Update the title genreDTO
            existingGenre.Title = genreDTO.Title;

            // Save the updated role to the database
            await _genreRepository.UpdateAsync(existingGenre);

            return Ok(existingGenre);
        }
    }
}
