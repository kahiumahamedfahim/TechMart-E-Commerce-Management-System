using TechMart_E_Commerce_Management_System.Services.Common;
using TechMart_E_Commerce_Management_System.Services.File.Interfaces;
namespace TechMart_E_Commerce_Management_System.Services.File.Implementations
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _logger;
        public FileService(ILogger<FileService> logger)
        {

            _logger = logger;
        }
        private bool IsValidExtension(IFormFile file,
            List<string> allowedExtensions)
        {
            var extension =
            Path.GetExtension(file.FileName)
            .ToLower();
            return allowedExtensions.Contains(extension);
        }
        private bool isValidFileSize(IFormFile file,
            long maxFileSIze)
        {
            var result =
                file.Length <= maxFileSIze;
            return result;
        }
        private string GenerateFileName(string originalFileName)
        {
            var firstName = Guid.NewGuid().ToString();
            var lastName = Path.GetExtension(originalFileName);
            var name = firstName + lastName;
            return name;
        }
        private string CreateFolderNamepath(string folderName)
        {
            var folderPath =
               Path.Combine(Directory.GetCurrentDirectory(),
               "wwwwroot",
               "uploads",
               folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return folderPath;
        }

        public async Task<FileUploadResult?> UploadImageAsync(IFormFile? file, string folderName,
            List<string> allowedExtensions,
            long maxFileSize)
        {
            var result =
                new FileUploadResult();
            try
            {
                if (file == null || file.Length == 0)
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = "No file seletected!";
                    return result;

                }
                if (!IsValidExtension(file, allowedExtensions))
                {
                    _logger.LogWarning("Invalid file Extension: {FileName}", file.FileName);
                    result.IsSuccess = false;
                    result.ErrorMessage = "Invalid file typoe.";
                    return result;
                }
                if (!isValidFileSize(file, maxFileSize))
                {

                    _logger.LogWarning("File size exceeded : {FileName}", file.FileName);
                    result.IsSuccess = false;
                    result.ErrorMessage = "File Size exceeded.";
                    return result;

                }
                var fileName =
                    GenerateFileName(file.FileName);
                var folderPath =
                    CreateFolderNamepath(folderName);
                var filePath =
                    Path.Combine(folderPath, fileName);

                using var stream =
                    new FileStream(
                        filePath,
                        FileMode.Create);

                await file.CopyToAsync(stream);

                result.IsSuccess = true;

                result.FileName = fileName;

                result.FilePath =
                    $"/uploads/{folderName}/{fileName}";

                _logger.LogInformation(
                    "File uploaded successfully. File: {FileName}",
                    fileName);

                return result;


            }
            catch (Exception ex)
            {
                _logger.LogError(
            ex,
            "File upload failed.");

                result.IsSuccess = false;
                result.ErrorMessage =
                    "An error occurred while uploading the file.";

                return result;
            }
        }
    }
}
