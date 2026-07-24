using TechMart_E_Commerce_Management_System.Data.Entities;

namespace TechMart_E_Commerce_Management_System.Repositories.Interfaces
{
    public interface ICategoryRepository :
        IGenericeRepository<Catagory, int>
    {
        Task<Catagory?> GetByCodeAsync(string code);
        Task<bool> ExistsByNameAsync(string name);
        Task<IEnumerable<Catagory>> SearchAsync(string keyword);
        Task<Catagory?> GetLastCatagoryAsync();
        Task<Catagory> GetByCatagoryId(int catagoryId);


    }
}
