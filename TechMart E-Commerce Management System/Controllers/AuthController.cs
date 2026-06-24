using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechMart_E_Commerce_Management_System.Services.Auth.interfaces;
using TechMart_E_Commerce_Management_System.ViewModels;

namespace TechMart_E_Commerce_Management_System.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVIewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result =
                await _authService.RegisterAsync(model);
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
                nameof(Login));
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user =
                await _authService.ValidateUserAsync(model);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login credentials,");
                return View(model);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,
                user.Id.ToString()),

                new Claim(ClaimTypes.Name,
                user.Name ?? string.Empty),


                new Claim(ClaimTypes.Email,
                user.Email ?? string.Empty),

                new Claim(
            ClaimTypes.Role,
            user.Role.ToString()),
                new Claim(
            "UserId",
            user.UserId ?? string.Empty)


            };
            var identity = new ClaimsIdentity(
                        claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

            var principal =
                new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal);

            return RedirectToAction(
                "Index",
                "Home");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(
                nameof(Login));
        }
        [HttpGet]
        public IActionResult ResendOtp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResendOtp(
            ResendOtpViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result =
                await _authService
                    .ResendVerificationCodeAsync(model);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(
                    "",
                    result.Message);

                return View(model);
            }

            TempData["Success"] =
                result.Message;

            return RedirectToAction(
                nameof(VerifyEmail));
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(
           ForgetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result =
                await _authService.ForgetPasswordAsync(model.Email);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(model);

            }
            TempData["Email"] = model.Email;
            TempData["Success"] =
                result.Message;
            return RedirectToAction(nameof(VerifyResetCode));
        }


        [HttpGet]
        public IActionResult VerifyResetCode()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyResetCode(
            VerifyResetCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var email =
                TempData["Email"]?.ToString();
            TempData.Keep("Email");
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("", "Session expired.Please try again");
                return View(model);
            }
            var result =
                await _authService.VerifyResetCodeAsync(email,
                model.ResetCode);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(model);
            }
            TempData["ResetCode"] = model.ResetCode;
            return RedirectToAction(nameof(ResetPassword));
        }


        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(
            ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var email =
                TempData["Email"]?.ToString();
            var resetCode =
                TempData["ResetCode"]?.ToString();

            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(resetCode))
            {
                ModelState.AddModelError
                    ("", "Session Expired.Please try again.");
                return View(model);
            }
            var result =
                await _authService.ResetPasswordAsync(email,
                resetCode, model.Password);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("",
                    result.Message);
                return View(model);
            }
            TempData["Success"] =
                result.Message;
            return RedirectToAction(nameof(Login));
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
    }
}
