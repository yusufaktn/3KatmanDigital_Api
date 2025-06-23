using _3KatmanDigital_API.Repository.Interface;
using Entitiy;
using Entitiy.Models;

namespace _3KatmanDigital_API.Repository.Repo
{
    public class ProjectImageRepo:GenericRepo<ProjectImages>,IProjectImageRepo
    {
        public ProjectImageRepo(AppDbContext context):base(context)
        {
            
        }
    }
}
