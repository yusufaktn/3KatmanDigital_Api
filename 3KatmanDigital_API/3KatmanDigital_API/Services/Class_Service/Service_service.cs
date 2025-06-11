using _3KatmanDigital_API.Repository.Interface;
using _3KatmanDigital_API.Services.Interface;
using Entitiy.Models;

namespace _3KatmanDigital_API.Services.Class_Service
{
    public class Service_service : IService_Service
    {
        private readonly IServiceRepo _serviceRepo;
        public Service_service(IServiceRepo serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }
        public async Task<Service> AddServiceAsync(Service service)
        {
           await  _serviceRepo.AddAsync(service);
            return service;
        }

        public async Task<bool> DeleteServiceAsync(Guid id)
        {
         
            return await _serviceRepo.DeleteAsync(id);

        }

        public async Task<List<Service>> GetAllServicesAsync()
        {
            return await _serviceRepo.GetAllAsync();
        }

        public async Task<Service> GetServiceByIdAsync(Guid id)
        {
            return await _serviceRepo.GetByIdAsync(id);
        }

        public async Task<Service> UpdateServiceAsync(Service service)
        {
            
            return await _serviceRepo.UpdateAsync(service);
        }
    }
}
