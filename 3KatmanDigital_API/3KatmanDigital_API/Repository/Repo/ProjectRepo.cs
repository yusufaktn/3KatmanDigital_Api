using _3KatmanDigital_API.Repository.Interface;
using Entitiy;
using Entitiy.Models;
using Microsoft.EntityFrameworkCore;

namespace _3KatmanDigital_API.Repository.Repo
{
    public class ProjectRepo : GenericRepo<Project>, IProjectRepo
    {
        public ProjectRepo(AppDbContext context) : base(context)
        {
            
        }

        public async Task<Project> GetProjectWithImageAsync(Guid id)
        {
            var projectwithimage = await _context.Projects
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.ID == id);
            if (projectwithimage.Images==null)
            {
                throw new Exception("Project not found or has no images.");
            }
            return projectwithimage;
        }

        public async Task<List<Project>> GetProjectWithImageAllAsync()
        {
            var projectwithimage = await _context.Projects
                .Include(p => p.Images)
                .ToListAsync();


            if (projectwithimage == null)
            {
                throw new Exception("Project not found or has no images.");
            }
            return projectwithimage;
        }

        public async Task UpdatePojectAsyncWithImage(Project project)
        {
            var existingProject = await _context.Projects
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.ID == project.ID);

            if (existingProject == null)
            {
                throw new Exception("Project not found.");
            }
            existingProject.Title = project.Title;
            existingProject.Description = project.Description;
            existingProject.CategoryID = project.CategoryID;
            existingProject.Images = project.Images ?? new List<ProjectImages>();
            _context.Projects.Update(existingProject);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Project>> GetProjectWithImageCategoryIDAsync(Guid id)
        {
            var project = await _context.Projects.Include(p => p.Images).Where(c => c.CategoryID == id).ToListAsync();

            return project;
        }
    }
}
