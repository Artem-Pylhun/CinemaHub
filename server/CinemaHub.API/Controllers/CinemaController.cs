using AutoMapper;
using CinemaHub.Domain.Entities;
using CinemaHub.Infrastructure.DTOs;
using CinemaHub.Repositories.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly IRepository<Cinema, Guid> _cinemaRepository;
        private readonly IMapper _mapper;
        public CinemaController(IRepository<Cinema, Guid> cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var cinemas = await _cinemaRepository.GetAllAsync();
            return Ok(cinemas);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddGenre(CinemaCreateDto cinema)
        {
            if (cinema == null)
            {
                return BadRequest("Cinema wasn't found");
            }
            await _cinemaRepository.CreateAsync(_mapper.Map<Cinema>(cinema));
            return Ok(cinema);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCinema(Guid id)
        {
            var cinema = await _cinemaRepository.GetAsync(id);
            if (cinema == null)
            {
                return NotFound("Cinema not found");
            }
            await _cinemaRepository.DeleteAsync(id);
            return Ok($"Cinema {cinema.Title} deleted");
        }
    }
}
