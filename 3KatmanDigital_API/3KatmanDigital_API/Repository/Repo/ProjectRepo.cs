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
    }
}
