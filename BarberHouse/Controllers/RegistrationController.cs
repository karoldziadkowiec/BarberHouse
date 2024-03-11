using BarberHouse.Models;
using BarberHouse.Models.DTOs;
using BarberHouse.Repositories.Classes;
using BarberHouse.Repositories.Interfaces;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberHouse.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationController(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            try
            {
                var existingUser = await _registrationRepository.GetUserByEmail(model.Email);
                if (existingUser != null)
                {
                    return BadRequest("Email is already registered.");
                }

                var newUser = await _registrationRepository.RegisterUser(model);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
