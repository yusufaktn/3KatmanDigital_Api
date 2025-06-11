using _3KatmanDigital_API.Repository.Interface;
using _3KatmanDigital_API.Services.Interface;
using Entitiy.Models;

namespace _3KatmanDigital_API.Services.Class_Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepo _projectRepo;
        public ProjectService(IProjectRepo projectRepo)
        {
            _projectRepo = projectRepo;
        }
        public async Task<Project> AddProjectAsync(Project project)
        {
            await _projectRepo.AddAsync(project);
            return project;
        }

        public async Task<bool> DeleteProjectAsync(Guid id)
        {
            return  await _projectRepo.DeleteAsync(id);
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _projectRepo.GetAllAsync();
        }

        public Task<Project> GetProjectByIdAsync(Guid id)
        {
            return _projectRepo.GetByIdAsync(id);
        }

        public async Task<List<Project>> GetProjectsByCategoryIdAsync(Guid categoryId)
        {
            return await _projectRepo.GetWhereListAsync(p => p.CategoryID == categoryId);
        }
            

        public async Task<Project> UpdateProjectAsync(Project project)
        {
           return await _projectRepo.UpdateAsync(project);
        }
    }
}
