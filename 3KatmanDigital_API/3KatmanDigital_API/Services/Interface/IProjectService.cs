using _3KatmanDigital_API.DTO.Project;
using Entitiy.Models;
using Microsoft.AspNetCore.Http;

namespace _3KatmanDigital_API.Services.Interface
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> GetAllProjectsAsync();
        Task<ProjectDto> GetProjectByIdAsync(Guid id);
        Task<ProjectDto> AddProjectAsync(CreateProjectDto project );
        Task<ProjectDto> UpdateProjectAsync(UpdateProjectDto project);
        Task<bool> DeleteProjectAsync(Guid id);
        Task<List<ProjectDto>> GetProjectsByCategoryIdAsync(Guid categoryId);
        
        
    }
}
