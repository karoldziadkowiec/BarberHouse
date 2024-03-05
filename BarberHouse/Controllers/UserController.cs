using BarberHouse.Models;
using BarberHouse.Repositories.Classes;
using BarberHouse.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberHouse.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userRepository.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving users: {ex.Message}");
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            try
            {
                var user = await _userRepository.GetUserById(userId);
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

        [HttpGet("group/{groupId}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersByGroupId(int groupId)
        {
            try
            {
                var users = await _userRepository.GetUsersByGroupId(groupId);
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            try
            {
                await _userRepository.AddUser(user);
                return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding user: {ex.Message}");
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, User user)
        {
            try
            {
                if (userId != user.Id)
                {
                    return BadRequest("User id mismatch");
                }

                var existingUser = await _userRepository.GetUserById(userId);
                if (existingUser == null)
                {
                    return NotFound($"User with id {userId} not found");
                }

                await _userRepository.UpdateUser(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating user: {ex.Message}");
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> RemoveUser(int userId)
        {
            try
            {
                var existingUser = await _userRepository.GetUserById(userId);
                if (existingUser == null)
                {
                    return NotFound($"User with id {userId} not found");
                }

                await _userRepository.RemoveUser(userId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error removing user: {ex.Message}");
            }
        }

        [HttpGet("csv")]
        public async Task<IActionResult> GetUsersCsvFile()
        {
            try
            {
                var csvBytes = await _userRepository.GetUsersCsvBytes();
                return File(csvBytes, "application/octet-stream", "users.csv");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("search/{searchTerm}")]
        public async Task<ActionResult<IEnumerable<User>>> SearchUser(string searchTerm)
        {
            try
            {
                var users = await _userRepository.SearchUser(searchTerm);
                if (users == null)
                {
                    return NotFound();
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("partial/{searchTerm}")]
        public async Task<ActionResult<IEnumerable<User>>> SearchPartial(string searchTerm)
        {
            try
            {
                var users = await _userRepository.SearchPartial(searchTerm);
                if (users == null)
                {
                    return NotFound();
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("modify-to-barber")]
        public async Task<IActionResult> ModifyToBarber(User user)
        {
            try
            {
                await _userRepository.ModifyToBarber(user);
                return Ok("User modified to barber successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("remove-from-barber")]
        public async Task<IActionResult> RemoveFromBarber(User user)
        {
            try
            {
                await _userRepository.RemoveFromBarber(user);
                return Ok("User removed from barber successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
