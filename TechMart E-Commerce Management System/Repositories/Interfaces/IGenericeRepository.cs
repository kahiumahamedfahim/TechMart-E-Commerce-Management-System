using System.Linq.Expressions;

namespace TechMart_E_Commerce_Management_System.Repositories.Interfaces
{
    public interface IGenericeRepository<T>
        where T : class


    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(
            Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangeAsync();

    }
}
