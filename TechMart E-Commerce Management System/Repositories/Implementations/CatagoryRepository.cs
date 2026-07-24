using Microsoft.EntityFrameworkCore;
using TechMart_E_Commerce_Management_System.Data;
using TechMart_E_Commerce_Management_System.Data.Entities;
using TechMart_E_Commerce_Management_System.Repositories.Interfaces;

namespace TechMart_E_Commerce_Management_System.Repositories.Implementations
{
    public class CatagoryRepository
        : GenericRepository<Catagory, int>, ICategoryRepository
    {
        public CatagoryRepository(AppDbcontext context)
            : base(context)
        {

        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _dbSet.AnyAsync(c => c.Name == name);

        }

        public async Task<Catagory?> GetByCodeAsync(string code)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Code == code);
        }

        public async Task<Catagory?> GetLastCatagoryAsync()
        {
            var result =
                await _dbSet.OrderByDescending(c => c.Id)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Catagory>> SearchAsync(string keyword)
        {
            var result =
                await _dbSet.Where(c => c.Name.Contains(keyword) 
                ||
                c.Code.Contains(keyword))
                .ToListAsync();
            return result;
        }
    }
}
