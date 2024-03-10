using BarberHouse.Models;
using BarberHouse.Repositories.Classes;
using BarberHouse.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberHouse.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            try
            {
                var services = await _serviceRepository.GetAllServices();
                return Ok(services);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving service: {ex.Message}");
            }
        }

        [HttpGet("{serviceId}")]
        public async Task<IActionResult> GetServiceById(int serviceId)
        {
            try
            {
                var service = await _serviceRepository.GetServiceById(serviceId);
                if (service == null)
                {
                    return NotFound($"Service with id {serviceId} not found");
                }

                return Ok(service);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving service: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddService(Service service)
        {
            try
            {
                await _serviceRepository.AddService(service);
                return CreatedAtAction(nameof(GetServiceById), new { id = service.Id }, service);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding service: {ex.Message}");
            }
        }

        [HttpPut("{serviceId}")]
        public async Task<IActionResult> UpdateService(int serviceId, Service service)
        {
            try
            {
                if (serviceId != service.Id)
                {
                    return BadRequest("Service id mismatch");
                }

                var existingService = await _serviceRepository.GetServiceById(serviceId);
                if (existingService == null)
                {
                    return NotFound($"Service with id {serviceId} not found");
                }

                await _serviceRepository.UpdateService(service);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating service: {ex.Message}");
            }
        }

        [HttpDelete("{serviceId}")]
        public async Task<IActionResult> RemoveService(int serviceId)
        {
            try
            {
                var existingService = await _serviceRepository.GetServiceById(serviceId);
                if (existingService == null)
                {
                    return NotFound($"Service with id {serviceId} not found");
                }

                await _serviceRepository.RemoveService(serviceId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error removing service: {ex.Message}");
            }
        }
    }
}
