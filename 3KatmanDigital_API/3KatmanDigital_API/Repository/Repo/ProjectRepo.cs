using _3KatmanDigital_API.Repository.Interface;
using Entitiy;
using Entitiy.Models;

namespace _3KatmanDigital_API.Repository.Repo
{
    public class ProjectRepo : GenericRepo<Project>, IProjectRepo
    {
        public ProjectRepo(AppDbContext context) : base(context)
        {
        }
        
    
    }
}
