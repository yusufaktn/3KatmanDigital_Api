using _3KatmanDigital_API.Repository.Interface;
using Entitiy;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _3KatmanDigital_API.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepo(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }



        public async Task AddAsync(T entity)
        {
            await  _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                return false; // Entity not found
            }
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true; 

        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetWhereListAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
