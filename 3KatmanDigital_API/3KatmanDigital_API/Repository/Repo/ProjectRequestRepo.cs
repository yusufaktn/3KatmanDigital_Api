using _3KatmanDigital_API.Repository.Interface;
using Entitiy;
using Entitiy.Models;

namespace _3KatmanDigital_API.Repository.Repo
{
    public class ProjectRequestRepo : GenericRepo<ProjectRequest>, IProjectRequestRepo
    {
        public ProjectRequestRepo(AppDbContext context) : base(context)
        {
        }
        
    }
    
    
}
