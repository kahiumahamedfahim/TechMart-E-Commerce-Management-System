using TechMart_E_Commerce_Management_System.Services.Common;
using TechMart_E_Commerce_Management_System.ViewModels;

namespace TechMart_E_Commerce_Management_System.Services.Admin.Interfaces
{
    public interface IAdminService
    {
        Task<ServiceResult> CreateAdminAsyn(CreateAdminViewModel
            model);
    }
}
