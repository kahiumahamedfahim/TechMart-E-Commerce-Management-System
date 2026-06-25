using TechMart_E_Commerce_Management_System.Services.Common;
using TechMart_E_Commerce_Management_System.ViewModels;

namespace TechMart_E_Commerce_Management_System.Services.Admin.Interfaces
{
    public interface IAdminService
    {

        Task<List<AdminListViewModel>> GetAdminsAsync(
    string? search);
        Task<ServiceResult> ToggleAdminStatusAsync(Guid id);
    }
}
