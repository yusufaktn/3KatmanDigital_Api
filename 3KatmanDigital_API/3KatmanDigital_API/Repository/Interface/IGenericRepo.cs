using System.Linq.Expressions;

namespace _3KatmanDigital_API.Repository.Interface
{
    public interface IGenericRepo<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetWhereListAsync(Expression<Func<T, bool>> expression);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        
    }
}
