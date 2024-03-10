using BarberHouse.Models;

namespace BarberHouse.Repositories.Interfaces
{
    public interface IServiceRepository
    {
        Task<IQueryable<Service>> GetAllServices();
        Task<Service> GetServiceById(int serviceId);
        Task AddService(Service service);
        Task UpdateService(Service service);
        Task RemoveService(int serviceId);
    }
}
