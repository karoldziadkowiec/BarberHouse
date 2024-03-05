using BarberHouse.Models;

namespace BarberHouse.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        Task<IQueryable<Group>> GetAllGroups();
        Task<Group> GetGroupById(int groupId);
        Task<Group> SearchGroupByName(string groupName);
        Task AddGroup(Group group);
        Task UpdateGroup(Group group);
        Task RemoveGroup(int groupId);
    }
}