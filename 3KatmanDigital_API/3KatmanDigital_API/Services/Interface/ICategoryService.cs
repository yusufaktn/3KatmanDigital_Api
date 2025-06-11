using Entitiy.Models;

namespace _3KatmanDigital_API.Services.Interface
{
    public interface ICategoryService
    {
        Task <List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(Guid id);
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(Guid id);


    }
}
