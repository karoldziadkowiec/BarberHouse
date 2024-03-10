using BarberHouse.Models;
using BarberHouse.Repositories.Classes;
using BarberHouse.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberHouse.Controllers
{
    [Route("api/dates")]
    [ApiController]
    public class DateController : ControllerBase
    {
        private readonly IDateRepository _dateRepository;

        public DateController(IDateRepository dateRepository)
        {
            _dateRepository = dateRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDates()
        {
            try
            {
                var dates = await _dateRepository.GetAllDates();
                return Ok(dates);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving date: {ex.Message}");
            }
        }

        [HttpGet("{dateId}")]
        public async Task<IActionResult> GetDateById(int dateId)
        {
            try
            {
                var date = await _dateRepository.GetDateById(dateId);
                if (date == null)
                {
                    return NotFound($"Date with id {dateId} not found");
                }

                return Ok(date);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving date: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddDate(Date date)
        {
            try
            {
                await _dateRepository.AddDate(date);
                return CreatedAtAction(nameof(GetDateById), new { id = date.Id }, date);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding date: {ex.Message}");
            }
        }

        [HttpPut("{dateId}")]
        public async Task<IActionResult> UpdateDate(int dateId, Date date)
        {
            try
            {
                if (dateId != date.Id)
                {
                    return BadRequest("Date id mismatch");
                }

                var existingDate = await _dateRepository.GetDateById(dateId);
                if (existingDate == null)
                {
                    return NotFound($"Date with id {dateId} not found");
                }

                await _dateRepository.UpdateDate(date);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating date: {ex.Message}");
            }
        }

        [HttpDelete("{dateId}")]
        public async Task<IActionResult> RemoveDate(int dateId)
        {
            try
            {
                var existingDate = await _dateRepository.GetDateById(dateId);
                if (existingDate == null)
                {
                    return NotFound($"Date with id {dateId} not found");
                }

                await _dateRepository.RemoveDate(dateId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error removing date: {ex.Message}");
            }
        }
    }
}
