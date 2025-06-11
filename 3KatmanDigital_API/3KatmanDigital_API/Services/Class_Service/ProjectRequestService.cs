using _3KatmanDigital_API.Repository.Interface;
using _3KatmanDigital_API.Services.Interface;
using Entitiy.Models;

namespace _3KatmanDigital_API.Services.Class_Service
{
    public class ProjectRequestService : IProjectRequestService
    {
        private readonly IProjectRequestRepo _projectRequestRepo;
        public ProjectRequestService(IProjectRequestRepo projectRequestRepo)
        {
            _projectRequestRepo = projectRequestRepo;
        }
        public async Task<ProjectRequest> AddProjectRequestAsync(ProjectRequest projectRequest)
        {
            await _projectRequestRepo.AddAsync(projectRequest);
            return projectRequest;
        }

        public async Task<bool> DeleteProjectRequestAsync(Guid id)
        {
          return  await _projectRequestRepo.DeleteAsync(id);
        }

        public async Task<List<ProjectRequest>> GetAllProjectRequestsAsync()
        {
            return await _projectRequestRepo.GetAllAsync();
        }

        public async Task<ProjectRequest> GetProjectRequestByIdAsync(Guid id)
        {
            return await _projectRequestRepo.GetByIdAsync(id);
        }

        public async Task<List<ProjectRequest>> GetProjectRequestsByCategoryIdAsync(Guid CategoryId)
        {
            return await _projectRequestRepo.GetWhereListAsync(pr => pr.CategoryID == CategoryId);

        }

        public async Task<ProjectRequest> UpdateProjectRequestAsync(ProjectRequest projectRequest)
        {
            return await _projectRequestRepo.UpdateAsync(projectRequest);
        }
    }
}
