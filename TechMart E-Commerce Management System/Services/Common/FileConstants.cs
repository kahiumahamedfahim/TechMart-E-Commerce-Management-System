namespace TechMart_E_Commerce_Management_System.Services.Common
{
    public class FileConstants
    {
        public static readonly List<string>
            ImageExtensions = new()
        {
             ".jpg",
                ".jpeg",
                ".png",
                ".webp"
        };
        public const long ProfileImageMaxSize =
            2 * 1024 * 1024;
        public const long ProductImageMaxSize =
           5 * 1024 * 1024;

    }
}
