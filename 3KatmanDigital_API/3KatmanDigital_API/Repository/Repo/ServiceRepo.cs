using _3KatmanDigital_API.Repository.Interface;
using Entitiy;
using Entitiy.Models;

namespace _3KatmanDigital_API.Repository.Repo
{
    public class ServiceRepo : GenericRepo<Service>, IServiceRepo
    {
        public ServiceRepo(AppDbContext context): base(context)
        {
            
        }

    }
}
