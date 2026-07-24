using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechMart_E_Commerce_Management_System.Services.Catagories.Interfaces;
using TechMart_E_Commerce_Management_System.ViewModels.CatagoriesDTO;

namespace TechMart_E_Commerce_Management_System.Controllers
{
    [Authorize]
    public class CatagoryController : Controller
    {
        private readonly ICatagoryService _catagoryService;
        public CatagoryController(ICatagoryService catagoryService)
        {
            _catagoryService = catagoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var catagories = await _catagoryService.GetAllCatagoriesAsync();
            return View(catagories);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _catagoryService.CreateCatagoryAsync(model);


            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(model);
            }

            TempData["Success"] = result.Message;

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _catagoryService.GetUpdateCategoryAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Edit(UpdateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _catagoryService.UpdateCatagoryAsync(model);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(model);
            }

            TempData["Success"] = result.Message;

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _catagoryService.DeleteCatagory(id);


            TempData[result.IsSuccess ? "Success" : "Error"] = result.Message;

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Search(string keyword)
        {
            var categories =
                await _catagoryService.SearchCatagoriesAsync(keyword);

            return View("Index", categories);
        }
    }
}
