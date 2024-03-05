using BarberHouse.Database;
using BarberHouse.Models;
using BarberHouse.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

using Group = BarberHouse.Models.Group;

namespace BarberHouse.Repositories.Classes
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDbContext _context;

        public GroupRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Group>> GetAllGroups()
            => await Task.FromResult(_context.Groups.OrderBy(g => g.Id));

        public async Task<Group> GetGroupById(int groupId)
            => await _context.Groups.FirstOrDefaultAsync(g => g.Id == groupId);

        public async Task<Group> SearchGroupByName(string groupName)
            => await _context.Groups.FirstOrDefaultAsync(g => g.Name == groupName);

        public async Task AddGroup(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGroup(Group group)
        {
            var existingGroup = await _context.Groups.FindAsync(group.Id);

            if (existingGroup != null)
            {
                existingGroup.Name = group.Name;

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveGroup(int groupId)
        {
            var group = await _context.Groups.FirstOrDefaultAsync(g => g.Id == groupId);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }
    }
}
