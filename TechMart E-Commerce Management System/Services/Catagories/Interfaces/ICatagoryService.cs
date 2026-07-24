using TechMart_E_Commerce_Management_System.Services.Common;
using TechMart_E_Commerce_Management_System.ViewModels.CatagoriesDTO;

namespace TechMart_E_Commerce_Management_System.Services.Catagories.Interfaces
{
    public interface ICatagoryService
    {
        Task<ServiceResult> CreateCatagoryAsync(CreateCategoryViewModel model);
        Task<ServiceResult> UpdateCatagoryAsync(UpdateCategoryViewModel model);
        Task<IEnumerable<CatagoryListViewModel>> GetAllCatagoriesAsync();
        Task<ServiceResult> DeleteCatagory(int id);
        Task<CatagoryListViewModel> GetCatagorById(int id);
        Task<IEnumerable<CatagoryListViewModel>> SearchCatagoriesAsync(string keyword);

    }
}
