using Entitiy.Models;

namespace _3KatmanDigital_API.Services.Interface
{
    public interface IService_Service
    {
        Task<List<Service>> GetAllServicesAsync();
        Task<Service> GetServiceByIdAsync(Guid id);
        Task<Service> AddServiceAsync(Service service);
        Task<Service> UpdateServiceAsync(Service service);
        Task<bool> DeleteServiceAsync(Guid id);
        
    }
}
