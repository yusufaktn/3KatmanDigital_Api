using Entitiy.Models;

namespace _3KatmanDigital_API.Services.Interface
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(Guid id);
        Task<Project> AddProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(Project project);
        Task<bool> DeleteProjectAsync(Guid id);
        Task<List<Project>> GetProjectsByCategoryIdAsync(Guid categoryId);
        
        
    }
}
