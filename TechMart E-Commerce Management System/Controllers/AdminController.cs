using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechMart_E_Commerce_Management_System.Services.Admin.Interfaces;
using TechMart_E_Commerce_Management_System.Services.Auth.interfaces;
using TechMart_E_Commerce_Management_System.ViewModels.UsersDTO;

namespace TechMart_E_Commerce_Management_System.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IAuthService _authService;
        public AdminController(IAdminService adminService, IAuthService authService)
        {
            _adminService = adminService;

            _authService = authService;
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


        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult CreateAdmin()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreateAdmin(CreateAdminViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result =
                await _authService.CreateAdminAsync(model);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(model);
            }
            TempData["Email"] = model.Email;
            TempData["Success"] =
                result.Message;
            return RedirectToAction(nameof(VerifyEmail));
        }

        [HttpGet]
        public IActionResult VerifyEmail()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> VerifyEmail(
    VerifyEmailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var email =
                TempData["Email"]?.ToString();

            TempData.Keep("Email");

            if (string.IsNullOrWhiteSpace(email))
            {
                ModelState.AddModelError(
                    "",
                    "Verification session expired. Please register again.");

                return View(model);
            }

            var result =
                await _authService.VerifyEmailAsync(
                    email,
                    model.VerificationCode);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(
                    "",
                    result.Message);

                return View(model);
            }

            TempData.Remove("Email");

            TempData["Success"] =
                result.Message;

            return RedirectToAction(
                nameof(AdminList));
        }

    }
}
