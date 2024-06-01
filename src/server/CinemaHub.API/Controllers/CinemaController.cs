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
        public async Task<ActionResult<Cinema>> AddGenre(CinemaCreateDto cinema)
        {
            if (cinema == null)
            {
                return BadRequest("Cinema wasn't found");
            }
            await _cinemaRepository.CreateAsync(_mapper.Map<Cinema>(cinema));
            return Ok(cinema);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Cinema>> GetCinemaById(Guid id)
        {
            var cinema = await _cinemaRepository.GetAsync(id);
            if (cinema is null)
            {
                return NotFound("Cinema not found");
            }
            return Ok(cinema);
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteCinema(Guid id)
        {
            var cinema = await _cinemaRepository.GetAsync(id);
            if (cinema == null)
            {
                return NotFound("Cinema not found");
            }
            await _cinemaRepository.DeleteAsync(id);
            return Ok($"Cinema {cinema.Title} deleted");
        }
        [HttpPut("update")]
        public async Task<ActionResult<Cinema>> UpdateCinema(CinemaUpdateDto cinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);
            if (cinema == null)
            {
                return BadRequest("Cinema not found");
            }

            var existingCinema = await _cinemaRepository.GetAsync(cinema.Id);
            if (existingCinema is null)
            {
                return BadRequest("Cinema not found");
            }

            existingCinema.Title = cinemaDto.Title;
            existingCinema.Location = cinemaDto.Location;
            existingCinema.PhoneNumber = cinemaDto.PhoneNumber;

            await _cinemaRepository.UpdateAsync(existingCinema);

            return Ok(existingCinema);
        }
    }
}
