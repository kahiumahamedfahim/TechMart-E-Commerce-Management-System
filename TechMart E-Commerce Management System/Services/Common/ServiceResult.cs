namespace TechMart_E_Commerce_Management_System.Services.Common
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public static ServiceResult Success(string message)
        {
            return new ServiceResult
            {
                IsSuccess
                = true,
                Message = message
            };
        }
        public static ServiceResult Failue(string message)
        {
            return new ServiceResult
            {
                IsSuccess = false,
                Message = message
            };
        }
    }
}
