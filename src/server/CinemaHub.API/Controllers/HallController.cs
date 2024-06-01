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
    public class HallController : ControllerBase
    {
        private readonly IRepository<Hall, Guid> _hallRepository;
        private readonly IRepository<Seat, Guid> _seatRepository;
        private readonly IMapper _mapper;

        public HallController(IRepository<Hall, Guid> hallRepository, IRepository<Seat, Guid> seatRepository, IMapper mapper)
        {
            _hallRepository = hallRepository;
            _seatRepository = seatRepository;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var halls = await _hallRepository.GetAllAsync();
            return Ok(halls);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Hall>> AddHall(HallCreateDto hall)
        {
            if (hall == null)
            {
                return BadRequest("Hall wasn't found");
            }
            var newHall = _mapper.Map<Hall>(hall);
            var seats = new List<Seat>();
            for (int i = 1; i <= newHall.RowsNumber; i++)
            {
                for (int j = 1; j <= newHall.ColumnsNumber; j++)
                {
                    var seat = new Seat()
                    {
                        IsVIP = hall.VipRows.Contains(i),
                        Row = i,
                        Column = j,
                        Number = (i - 1) * newHall.ColumnsNumber + j
                    };
                    seats.Add(seat);
                }
            }
            newHall.Seats = seats;
            await _hallRepository.CreateAsync(newHall);
            return Ok(hall);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hall>> GetHallById(Guid id)
        {
            var hall = await _hallRepository.GetAsync(id);
            if (hall is null)
            {
                return NotFound("Hall not found");
            }
            return Ok(hall);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteHall(Guid id)
        {
            var hall = await _hallRepository.GetAsync(id);
            if (hall == null)
            {
                return NotFound("Hall not found");
            }
            var seats = (await _seatRepository.GetAllAsync()).Where(s => s.HallId == id);
            foreach (var seat in seats)
            {
                await _seatRepository.DeleteAsync(seat.Id);
            }
            await _hallRepository.DeleteAsync(id);
            return Ok(hall);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Hall>> UpdateHall(HallUpdateDto hallDto)
        {
            var hall = _mapper.Map<Hall>(hallDto);
            if (hall == null)
            {
                return BadRequest("Hall not found");
            }

            var existingHall = await _hallRepository.GetAsync(hall.Id);
            if (existingHall is null)
            {
                return BadRequest("Hall not found");
            }

            var seats = (await _seatRepository.GetAllAsync()).Where(s => s.HallId == hall.Id).ToList();
            foreach (var seat in seats)
            {
                await _seatRepository.DeleteAsync(seat.Id);
            }

            existingHall.Title = hallDto.Title;
            existingHall.RowsNumber = hallDto.RowsNumber;
            existingHall.ColumnsNumber = hallDto.ColumnsNumber;
            existingHall.ScreenSizeId = hallDto.ScreenSizeId;
            existingHall.CinemaId = hallDto.CinemaId;

            seats = new List<Seat>();
            for (int i = 1; i <= existingHall.RowsNumber; i++)
            {
                for (int j = 1; j <= existingHall.ColumnsNumber; j++)
                {
                    var seat = new Seat()
                    {
                        IsVIP = hallDto.VipRows.Contains(i),
                        Row = i,
                        Column = j,
                        Number = (i - 1) * existingHall.ColumnsNumber + j
                    };
                    seats.Add(seat);
                }
            }
            existingHall.Seats = seats;

            await _hallRepository.UpdateAsync(existingHall);
            return Ok(existingHall);
        }
    }
}
