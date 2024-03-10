using BarberHouse.Models;

namespace BarberHouse.Repositories.Interfaces
{
    public interface IVisitRepository
    {
        Task<IQueryable<Visit>> GetAllVisits();
        Task<Visit> GetVisitById(int visitId);
        Task AddVisit(Visit visit);
        Task UpdateVisit(Visit visit);
        Task RemoveVisit(int visitId);
    }
}
