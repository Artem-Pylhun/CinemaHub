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
    public class ScreenSizeController : ControllerBase
    {
        private readonly IRepository<ScreenSize, Guid> _screeSizeRepository;
        private readonly IMapper _mapper;

        public ScreenSizeController(IRepository<ScreenSize, Guid> sreenSizeRepository, IMapper mapper)
        {
            _screeSizeRepository = sreenSizeRepository;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var screenSizes = await _screeSizeRepository.GetAllAsync();
            return Ok(screenSizes);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ScreenSize>> AddMovie(ScreenSizeCreateDto screenSize)
        {
            if (screenSize == null)
            {
                return BadRequest("Screen size wasn't found");
            }
            await _screeSizeRepository.CreateAsync(_mapper.Map<ScreenSize>(screenSize));
            return Ok(screenSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScreenSize>> GetScreenSizeById(Guid id)
        {
            var screenSize = await _screeSizeRepository.GetAsync(id);
            if (screenSize is null)
            {
                return NotFound("Screen size not found");
            }
            return Ok(screenSize);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteScreenSize(Guid id)
        {
            var screenSize = await _screeSizeRepository.GetAsync(id);
            if (screenSize == null)
            {
                return NotFound("Screen size not found");
            }
            await _screeSizeRepository.DeleteAsync(id);
            return Ok(screenSize);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ScreenSize>> UpdateScreenSize(ScreenSizeUpdateDto screenSizeDto)
        {
            var screenSize = _mapper.Map<ScreenSize>(screenSizeDto);
            if (screenSize == null)
            {
                return BadRequest("Screen size not found");
            }

            var existingScreenSize = await _screeSizeRepository.GetAsync(screenSize.Id);
            if (existingScreenSize is null)
            {
                return BadRequest("Screen size not found");
            }

            existingScreenSize.Width = screenSizeDto.Width;
            existingScreenSize.Height = screenSizeDto.Height;

            await _screeSizeRepository.UpdateAsync(existingScreenSize);
            return Ok(existingScreenSize);
        }
    }
}
