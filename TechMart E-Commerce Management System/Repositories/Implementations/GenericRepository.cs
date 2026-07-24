using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechMart_E_Commerce_Management_System.Data;
using TechMart_E_Commerce_Management_System.Repositories.Interfaces;

namespace TechMart_E_Commerce_Management_System.Repositories.Implementations
{
    public class GenericRepository<TEntity, TKey>
        : IGenericeRepository<TEntity, TKey>
        where TEntity : class
    {
        protected readonly AppDbcontext _context;
        protected readonly DbSet<TEntity> _dbSet;
        public GenericRepository(AppDbcontext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();

        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(
            Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet
                .Where(predicate)
                .ToListAsync();
        }



        public async Task<IEnumerable<TEntity?>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }



        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}