
using _3KatmanDigital_API.Repository.Interface;
using _3KatmanDigital_API.Services.Interface;
using Entitiy.Models;

namespace _3KatmanDigital_API.Services.Class_Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _categoryRepo.AddAsync(category);
            return category;
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            return await _categoryRepo.DeleteAsync(id);
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepo.GetAllAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            return await _categoryRepo.GetByIdAsync(id);
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            return await _categoryRepo.UpdateAsync(category);
        }
    }
}
