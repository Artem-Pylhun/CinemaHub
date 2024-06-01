using AutoMapper;
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
    public class ActorController : ControllerBase
    {
        private readonly IRepository<Actor, Guid> _actorRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public ActorController(IRepository<Actor, Guid> actorRepository, IMapper mapper, IFileService fileService)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
            _fileService = fileService;
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllActors()
        {
            var marathons = _mapper.Map<IEnumerable<ActorDto>>(await _actorRepository.GetAllAsync());
            return Ok(marathons);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Actor>> AddActor([FromForm] ActorCreateDto actor)
        {
            if (actor == null)
            {
                return BadRequest(actor);
            }
            if (actor.ImageFile != null)
            {
                var fileResult = _fileService.SaveIFormFile(actor.ImageFile, "actors");
                if (fileResult.Contains("Only") || fileResult.Contains("Error"))
                {
                    return BadRequest(fileResult);
                }
                else
                {
                    actor.ImagePath = fileResult;
                }
                await _actorRepository.CreateAsync(_mapper.Map<Actor>(actor));
                return Ok(actor);
            }
            await _actorRepository.CreateAsync(_mapper.Map<Actor>(actor));
            return Ok(actor);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Actor>>> GetActor(Guid id)
        {
            var actor = await _actorRepository.GetAsync(id);
            if (actor is null)
                return NotFound("Actor not found");
            return Ok(actor);
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteActor(Guid id)
        {
            var actor = await _actorRepository.GetAsync(id);
            if (actor is null)
                return NotFound("Actor not found");
            _fileService.DeleteImage(actor.ImagePath, "actors");
            await _actorRepository.DeleteAsync(id);
            return Ok($"Actor {actor.FullName} deleted");
        }
        [HttpPut("update")]
        public async Task<ActionResult<Actor>> UpdateActor(ActorUpdateDto actorDTO)
        {
            var actor = _mapper.Map<Actor>(actorDTO);
            if (actor == null)
            {
                return BadRequest("Actor not found");
            }

            // Retrieve the existing actor from the database
            var existingActor = await _actorRepository.GetAsync(actor.Id);
            if (existingActor == null)
            {
                return NotFound("Actor not found");
            }

            // Update the title and description
            existingActor.FullName = actorDTO.FullName;
            existingActor.Gender = actorDTO.Gender;
            existingActor.DateOfBirth = actorDTO.DateOfBirth;
            existingActor.Nationality = actorDTO.Nationality;

            if (actorDTO.ImageFile != null)
            {
                _fileService.DeleteImage(existingActor.ImagePath, "actors");
                var fileResult = _fileService.SaveIFormFile(actorDTO.ImageFile, "actors");
                if (fileResult.Contains("Only") || fileResult.Contains("Error"))
                {
                    return BadRequest(fileResult);
                }
                else
                {
                    existingActor.ImagePath = fileResult;
                }
            }

            await _actorRepository.UpdateAsync(existingActor);

            return Ok(existingActor);
        }
    }
}
