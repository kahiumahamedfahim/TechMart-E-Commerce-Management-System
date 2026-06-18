namespace TechMart_E_Commerce_Management_System.Services.Common
{
    public class FileUploadResult
    {
        public bool IsSuccess { get; set; }
        public string? FilePath { get; set; }
        public string? FileName { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
