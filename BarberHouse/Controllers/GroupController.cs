using BarberHouse.Models;
using BarberHouse.Repositories.Classes;
using BarberHouse.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberHouse.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;

        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroups()
        {
            try
            {
                var groups = await _groupRepository.GetAllGroups();
                return Ok(groups);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving groups: {ex.Message}");
            }
        }

        [HttpGet("{groupId}")]
        public async Task<IActionResult> GetGroupById(int groupId)
        {
            try
            {
                var group = await _groupRepository.GetGroupById(groupId);
                if (group == null)
                {
                    return NotFound($"Group with id {groupId} not found");
                }

                return Ok(group);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving group: {ex.Message}");
            }
        }

        [HttpGet("search/{groupName}")]
        public async Task<IActionResult> SearchGroupByName(string groupName)
        {
            try
            {
                var group = await _groupRepository.SearchGroupByName(groupName);
                if (group == null)
                {
                    return NotFound($"Group with id {groupName} not found");
                }

                return Ok(group);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving group: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddGroup(Group group)
        {
            try
            {
                await _groupRepository.AddGroup(group);
                return CreatedAtAction(nameof(GetGroupById), new { id = group.Id }, group);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding group: {ex.Message}");
            }
        }

        [HttpPut("{groupId}")]
        public async Task<IActionResult> UpdateGroup(int groupId, Group group)
        {
            try
            {
                if (groupId != group.Id)
                {
                    return BadRequest("Group id mismatch");
                }

                var existingGroup = await _groupRepository.GetGroupById(groupId);
                if (existingGroup == null)
                {
                    return NotFound($"Group with id {groupId} not found");
                }

                await _groupRepository.UpdateGroup(group);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating group: {ex.Message}");
            }
        }

        [HttpDelete("{groupId}")]
        public async Task<IActionResult> RemoveGroup(int groupId)
        {
            try
            {
                var existingGroup = await _groupRepository.GetGroupById(groupId);
                if (existingGroup == null)
                {
                    return NotFound($"Group with id {groupId} not found");
                }

                await _groupRepository.RemoveGroup(groupId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error removing group: {ex.Message}");
            }
        }
    }
}
