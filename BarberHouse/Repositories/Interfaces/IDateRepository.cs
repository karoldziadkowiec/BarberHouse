using BarberHouse.Models;

namespace BarberHouse.Repositories.Interfaces
{
    public interface IDateRepository
    {
        Task<IQueryable<Date>> GetAllDates();
        Task<Date> GetDateById(int dateId);
        Task AddDate(Date date);
        Task UpdateDate(Date date);
        Task RemoveDate(int dateId);
    }
}
