using AutoMapper;
using CinemaHub.API.Implementation;
using CinemaHub.API.Interfaces;
using CinemaHub.Domain.Entities;
using CinemaHub.Infrastructure.DTOs;
using CinemaHub.Repositories.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IRepository<Director, Guid> _directorRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public DirectorController(IRepository<Director, Guid> directorRepository, IMapper mapper, IFileService fileService)
        {
            _directorRepository = directorRepository;
            _mapper = mapper;
            _fileService = fileService;
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllDirectors()
        {
            var marathons = _mapper.Map<IEnumerable<Director>>(await _directorRepository.GetAllAsync());
            return Ok(marathons);
        }
        [HttpPost("add")]
        public async Task<ActionResult<Director>> AddDirector([FromBody] DirectorCreateDto director)
        {
            if (director == null)
            {
                return BadRequest(director);
            }
            if (director.ImageFile != null || director.ClientImageFile != null)
            {
                var fileResult = "Only";
                if (director.ClientImageFile != null)
                {
                    fileResult = _fileService.SaveImage(director.ClientImageFile, "directors");
                }
                else if (director.ImageFile != null)
                {
                    fileResult = _fileService.SaveIFormFile(director.ImageFile, "directors");
                }

                if (fileResult.Contains("Only") || fileResult.Contains("Error"))
                {
                    return BadRequest(fileResult);
                }
                else
                {
                    director.ImagePath = fileResult;
                }
                await _directorRepository.CreateAsync(_mapper.Map<Director>(director));
                return Ok(director);
            }
            await _directorRepository.CreateAsync(_mapper.Map<Director>(director));
            return Ok(director);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Director>>> GetDirector(Guid id)
        {
            var director = await _directorRepository.GetAsync(id);
            if (director is null)
                return NotFound("Director not found");
            return Ok(director);
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteDirector(Guid id)
        {
            var director = await _directorRepository.GetAsync(id);
            if (director is null)
                return NotFound("Director not found");
            _fileService.DeleteImage(director.ImagePath, "directors");
            await _directorRepository.DeleteAsync(id);
            return Ok($"Director {director.FullName} deleted");
        }
        [HttpPut("update")]
        public async Task<ActionResult<Director>> UpdateDirector([FromBody]DirectorUpdateDto directorDTO)
        {
            var director = _mapper.Map<Director>(directorDTO);
            if (director == null)
            {
                return BadRequest("Director not found");
            }

            // Retrieve the existing director from the database
            var existingDirector = await _directorRepository.GetAsync(director.Id);
            if (existingDirector == null)
            {
                return NotFound("Director not found");
            }

            // Update the title and description
            existingDirector.FullName = directorDTO.FullName;
            existingDirector.Gender = directorDTO.Gender;
            existingDirector.DateOfBirth = directorDTO.DateOfBirth;
            existingDirector.Nationality = directorDTO.Nationality;

            if (directorDTO.ImageFile != null || directorDTO.ClientImageFile != null )
            {
                _fileService.DeleteImage(existingDirector.ImagePath, "directors");
                var fileResult = "Only";
                if (directorDTO.ClientImageFile != null)
                {
                    fileResult = _fileService.SaveImage(directorDTO.ClientImageFile, "directors");
                }
                else if (directorDTO.ImageFile != null)
                {
                    fileResult = _fileService.SaveIFormFile(directorDTO.ImageFile, "directors");
                }
                if (fileResult.Contains("Only") || fileResult.Contains("Error"))
                {
                    return BadRequest(fileResult);
                }
                else
                {
                    existingDirector.ImagePath = fileResult;
                }
            }

            await _directorRepository.UpdateAsync(existingDirector);

            return Ok(existingDirector);
        }
    }
}
