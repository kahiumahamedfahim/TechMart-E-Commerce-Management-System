using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechMart_E_Commerce_Management_System.Services.Profile.interfaces;
using TechMart_E_Commerce_Management_System.ViewModels;

namespace TechMart_E_Commerce_Management_System.Controllers
{

    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        public ProfileController(
            IProfileService profileService)
        {
            _profileService = profileService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userIdClaim =
                User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                return RedirectToAction("Login",
                    "Auth");
            }
            var userId = Guid.Parse(userIdClaim);
            var profile =
                await _profileService.GetProfileAsync(userId);
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var userIdClaim =
                User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                return RedirectToAction
                    ("Login", "Auth");
            }
            var userId = Guid.Parse(userIdClaim);
            var model =
                await _profileService.GetEditProfileAsync(userId);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
    EditProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userIdClaim =
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier);

            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                return RedirectToAction(
                    "Login",
                    "Auth");
            }

            var userId =
                Guid.Parse(userIdClaim);

            var result =
                await _profileService
                    .UpdateProfileAsync(
                        userId,
                        model);

            if (!result.IsSuccess)
            {
                var editModel =
                    await _profileService
                        .GetEditProfileAsync(userId);

                if (editModel != null)
                {
                    model.CurrentProfileImage =
                        editModel.CurrentProfileImage;
                }

                ModelState.AddModelError(
                    "",
                    result.Message);

                return View(model);
            }

            TempData["Success"] =
                result.Message;

            return RedirectToAction(
                nameof(Index));
        }
    }
}
