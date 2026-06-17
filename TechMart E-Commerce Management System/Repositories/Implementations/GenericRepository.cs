using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechMart_E_Commerce_Management_System.Data;
using TechMart_E_Commerce_Management_System.Repositories.Interfaces;

namespace TechMart_E_Commerce_Management_System.Repositories.Implementations
{
    public class GenericRepository<T>
        : IGenericeRepository<T>
        where T : class
    {
        protected readonly AppDbcontext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbcontext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
