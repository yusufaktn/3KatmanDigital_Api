using Entitiy.Models;

namespace _3KatmanDigital_API.Repository.Interface
{
    public interface IProjectRepo : IGenericRepo<Project>
    {
        Task<Project> GetProjectWithImageAsync(Guid id);
        Task<List<Project>> GetProjectWithImageAllAsync();
        Task UpdatePojectAsyncWithImage(Project project);
        Task <List<Project>>GetProjectWithImageCategoryIDAsync(Guid id);

    }
}
