using TechMart_E_Commerce_Management_System.Data.Entities;
using TechMart_E_Commerce_Management_System.Repositories.Interfaces;
using TechMart_E_Commerce_Management_System.Services.Catagories.Interfaces;
using TechMart_E_Commerce_Management_System.Services.Common;
using TechMart_E_Commerce_Management_System.Services.File.Interfaces;
using TechMart_E_Commerce_Management_System.ViewModels.CatagoriesDTO;

namespace TechMart_E_Commerce_Management_System.Services.Catagories.Implementations
{
    public class CatagoryService : ICatagoryService


    {
        private readonly ICategoryRepository _catRepo;
        private readonly IFileService _fileService;
        public CatagoryService(ICategoryRepository categoryRepo,
            IFileService fileService)
        {
            _catRepo = categoryRepo;
            _fileService = fileService;
        }
        private async Task<string> GenrateCatagoryCode()
        {
            var lastCatagory = await _catRepo.GetLastCatagoryAsync();

            if (lastCatagory == null)
            {
                return "CAT001";
            }
            var lastCode = lastCatagory.Code;
            var numberPart = lastCode.Substring(3);
            var number = int.Parse(numberPart);
            number++;
            return $"CAT{number:D3}";
        }
        public async Task<ServiceResult> CreateCatagoryAsync(CreateCategoryViewModel model)
        {
            try
            {
                var exists = await _catRepo.ExistsByNameAsync(model.Name);
                if (exists)
                {
                    return ServiceResult.Failue("catagory name already exists");
                }
                var code = await GenrateCatagoryCode();

                var catagory = new Catagory
                {
                    Name = model.Name,
                    Code = code,
                    Description = model.Description,
                    IsActive = model.IsActive,
                    CreatedAt = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow,
                };
                if (model.Image != null)
                {
                    var uploadResult = await _fileService.UploadImageAsync(
                        model.Image,
                        "categories",
                        FileConstants.ImageExtensions,
                        FileConstants.CategoryImageMaxSize);

                    if (!uploadResult.IsSuccess)
                    {
                        return ServiceResult.Failue(uploadResult.ErrorMessage);
                    }

                    catagory.ImagePath = uploadResult.FilePath;
                }
                await _catRepo.AddAsync(catagory);
                await _catRepo.SaveChangesAsync();
                return ServiceResult.Success("Catagory created successful!");

            }
            catch (Exception ex)
            {
                return ServiceResult.Failue("something went wrong!");
            }
        }

        public async Task<ServiceResult> DeleteCatagory(int id)
        {
            try
            {
                var catagory =
                   await _catRepo.GetByCatagoryId(id);
                if (catagory == null)
                {
                    return ServiceResult.Failue("Catagory not found");
                }
                _catRepo.Delete(catagory);

                await _catRepo.SaveChangesAsync();
                return ServiceResult.Success("catagory Deleted Sucessfully");

            }
            catch (Exception ex)
            {
                return ServiceResult.Failue("Something is wrong!");
            }
        }

        public async Task<IEnumerable<CatagoryListViewModel>> GetAllCatagoriesAsync()
        {
            var catagories = await _catRepo.GetAllAsync();
            if (catagories == null)
            {
                return null;
            }
            return catagories.Select(c => new CatagoryListViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Code = c.Code,
                Description = c.Description,
                IsActive = c.IsActive,
                ImagePath = c.ImagePath,
            });
        }

        public async Task<CatagoryListViewModel> GetCatagorById(int id)
        {
            var catagory = await _catRepo.GetByCatagoryId(id);

            if (catagory == null)
            {
                return null;
            }
            return new CatagoryListViewModel
            {
                Id = catagory.Id,
                Code = catagory.Code,
                Name = catagory.Name,
                Description = catagory.Description,
                IsActive = catagory.IsActive,
                ImagePath = catagory.ImagePath,
            };
        }

        public async Task<IEnumerable<CatagoryListViewModel>> SearchCatagoriesAsync(string keyword)
        {
            var catagories = await _catRepo.SearchAsync(keyword);
            if (catagories == null)
            {
                return null;
            }
            return catagories.Select(c => new CatagoryListViewModel
            {
                Id = c.Id,
                Code = c.Code,
                Name = c.Name,
                Description = c.Description,
                IsActive = c.IsActive,
                ImagePath = c.ImagePath,
            });

        }

        public async Task<ServiceResult> UpdateCatagoryAsync(UpdateCategoryViewModel model)
        {
            try
            {
                var catagory = await _catRepo.GetByCatagoryId(model.Id);

                if (catagory == null)
                {
                    return ServiceResult.Failue("Category not found!");
                }

                // Upload new image if provided
                if (model.Image != null)
                {
                    // Delete old image
                    await _fileService.DeleteFileAsync(catagory.ImagePath);

                    // Upload new image
                    var uploadResult = await _fileService.UploadImageAsync(
                        model.Image,
                        "categories",
                        FileConstants.ImageExtensions,
                        FileConstants.CategoryImageMaxSize);

                    if (!uploadResult.IsSuccess)
                    {
                        return ServiceResult.Failue(uploadResult.ErrorMessage!);
                    }

                    catagory.ImagePath = uploadResult.FilePath;
                }

                catagory.Name = model.Name;
                catagory.Description = model.Description;
                catagory.IsActive = model.IsActive;
                catagory.LastUpdated = DateTime.UtcNow;

                _catRepo.Update(catagory);
                await _catRepo.SaveChangesAsync();

                return ServiceResult.Success("Category updated successfully.");
            }
            catch (Exception)
            {
                return ServiceResult.Failue("Something went wrong!");
            }
        }
        public async Task<UpdateCategoryViewModel?> GetUpdateCategoryAsync(int id)
        {
            var category = await _catRepo.GetByCatagoryId(id);

            if (category == null)
            {
                return null;
            }

            return new UpdateCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                IsActive = category.IsActive,

                // Display current image in Edit page
                ExistingImagePath = category.ImagePath
            };
        }
    }
}
