using System.Linq.Expressions;

namespace TechMart_E_Commerce_Management_System.Repositories.Interfaces
{
    public interface IGenericeRepository<TEntity, Tkey>
        where TEntity : class


    {
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity?>> GetAllAsync();
        Task<IEnumerable<TEntity?>> FindAsync(
            Expression<Func<TEntity?, bool>> predicate);
        Task AddAsync(TEntity? entity);
        void Update(TEntity? entity);
        void Delete(TEntity? entity);
        Task SaveChangesAsync();

    }
}
