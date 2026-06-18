using TechMart_E_Commerce_Management_System.Services.Common;

namespace TechMart_E_Commerce_Management_System.Services.File.Interfaces
{
    public interface IFileService
    {
        Task<FileUploadResult?> UploadImageAsync(IFormFile? file,
            string folderName,
            List<string> allowedExtensions,
            long maxFileSize);
    }
}
