using _3KatmanDigital_API.Repository.Interface;
using Entitiy;
using Entitiy.Models;

namespace _3KatmanDigital_API.Repository.Repo
{
    public class CategoryRepo:GenericRepo<Category>,ICategoryRepo
    {
        public CategoryRepo(AppDbContext context) : base(context)
        {
        }
        
    }
}
