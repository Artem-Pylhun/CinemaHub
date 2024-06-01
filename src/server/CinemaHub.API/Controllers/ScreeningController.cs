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
    public class ScreeningController : ControllerBase
    {
        private readonly IRepository<Screening, Guid> _screeningRepository;
        private readonly IMapper _mapper;

        public ScreeningController(IRepository<Screening, Guid> screeningRepository, IMapper mapper)
        {
            _screeningRepository = screeningRepository;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var screening = await _screeningRepository.GetAllAsync();
            return Ok(screening);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Screening>> AddScreening(ScreeningCreateDto screening)
        {
            if (screening == null)
            {
                return BadRequest("Screening wasn't found");
            }

            await _screeningRepository.CreateAsync(_mapper.Map<Screening>(screening));
            return Ok(screening);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Screening>> GetScreeningById(Guid id)
        {
            var screening = await _screeningRepository.GetAsync(id);
            if (screening is null)
            {
                return NotFound("Screening not found");
            }
            return Ok(screening);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteScreening(Guid id)
        {
            var screening = await _screeningRepository.GetAsync(id);
            if (screening == null)
            {
                return NotFound("Screening not found");
            }
            await _screeningRepository.DeleteAsync(id);
            return Ok(screening);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Screening>> UpdateScreening(ScreeningUpdateDto screeningDto)
        {
            var screening = _mapper.Map<Screening>(screeningDto);
            if (screening == null)
            {
                return BadRequest("Screening not found");
            }

            var existingScreening = await _screeningRepository.GetAsync(screening.Id);
            if (existingScreening is null)
            {
                return BadRequest("Screening not found");
            }

            existingScreening.StartTime = screeningDto.StartTime;
            existingScreening.VIPTicketsPrice = screeningDto.VIPTicketsPrice;
            existingScreening.UsualTicketsPrice = screeningDto.UsualTicketsPrice;
            existingScreening.MovieId = screeningDto.MovieId;
            existingScreening.HallId = screeningDto.HallId;
            existingScreening.Is3DCapable =  screeningDto.Is3DCapable;

            await _screeningRepository.UpdateAsync(existingScreening);
            return Ok(existingScreening);
        }
    }
}
