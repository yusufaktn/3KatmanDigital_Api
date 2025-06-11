using Entitiy.Models;

namespace _3KatmanDigital_API.Services.Interface
{
    public interface IProjectRequestService
    {
        Task<List<ProjectRequest>> GetAllProjectRequestsAsync();
        Task<ProjectRequest> GetProjectRequestByIdAsync(Guid id);
        Task<ProjectRequest> AddProjectRequestAsync(ProjectRequest projectRequest);
        Task<ProjectRequest> UpdateProjectRequestAsync(ProjectRequest projectRequest);
        Task<bool> DeleteProjectRequestAsync(Guid id);
        Task<List<ProjectRequest>> GetProjectRequestsByCategoryIdAsync(Guid CategoryId);
    }
}
