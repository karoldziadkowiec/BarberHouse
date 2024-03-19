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

                return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            try
            {
                var user = await _registrationRepository.GetUserById(userId);
                if (user == null)
                {
                    return NotFound($"User with id {userId} not found");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving user: {ex.Message}");
            }
        }

        [HttpGet("search/{userEmail}")]
        public async Task<IActionResult> GetUserByEmail(string userEmail)
        {
            try
            {
                var user = await _registrationRepository.GetUserByEmail(userEmail);
                if (user == null)
                {
                    return NotFound($"User with email {userEmail} not found");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving user: {ex.Message}");
            }
        }

        [HttpGet("checkemail/{email}")]
        public async Task<IActionResult> CheckEmailExistence(string email)
        {
            try
            {
                var emailExists = await _registrationRepository.CheckIfEmailExist(email);
                return Ok(emailExists);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error checking email existence: {ex.Message}");
            }
        }
    }
}
