using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechMart_E_Commerce_Management_System.Services.Admin.Interfaces;

namespace TechMart_E_Commerce_Management_System.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> AdminList(
     string? search)
        {
            var admins =
                await _adminService.GetAdminsAsync(search);

            ViewBag.Search = search;

            return View(admins);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetAdmins(string? search)
        {
            var admins =
                await _adminService.GetAdminsAsync(search);

            return Json(admins);
        }
        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleAdminStatus(Guid id)
        {
            var result =
                await _adminService.ToggleAdminStatusAsync(id);

            return Json(new
            {
                success = result.IsSuccess,
                message = result.Message
            });
        }
    }
}
