using BarberHouse.Models;
using BarberHouse.Repositories.Classes;
using BarberHouse.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberHouse.Controllers
{
    [Route("api/visits")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IVisitRepository _visitRepository;

        public VisitController(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVisits()
        {
            try
            {
                var visits = await _visitRepository.GetAllVisits();
                return Ok(visits);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving visit: {ex.Message}");
            }
        }

        [HttpGet("{visitId}")]
        public async Task<IActionResult> GetVisitById(int visitId)
        {
            try
            {
                var visit = await _visitRepository.GetVisitById(visitId);
                if (visit == null)
                {
                    return NotFound($"Visit with id {visitId} not found");
                }

                return Ok(visit);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving visit: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddVisit(Visit visit)
        {
            try
            {
                await _visitRepository.AddVisit(visit);
                return CreatedAtAction(nameof(GetVisitById), new { id = visit.Id }, visit);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding visit: {ex.Message}");
            }
        }

        [HttpPut("{visitId}")]
        public async Task<IActionResult> UpdateVisit(int visitId, Visit visit)
        {
            try
            {
                if (visitId != visit.Id)
                {
                    return BadRequest("Visit id mismatch");
                }

                var existingVisit = await _visitRepository.GetVisitById(visitId);
                if (existingVisit == null)
                {
                    return NotFound($"Visit with id {visitId} not found");
                }

                await _visitRepository.UpdateVisit(visit);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating visit: {ex.Message}");
            }
        }

        [HttpDelete("{visitId}")]
        public async Task<IActionResult> RemoveVisit(int visitId)
        {
            try
            {
                var existingVisit = await _visitRepository.GetVisitById(visitId);
                if (existingVisit == null)
                {
                    return NotFound($"Visit with id {visitId} not found");
                }

                await _visitRepository.RemoveVisit(visitId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error removing visit: {ex.Message}");
            }
        }
    }
}
