using MatchMaker.Application.Services.Image;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;


namespace MatchMaker.Infrastructure.Services.Image
{
    public class ImageService : IImageService
    {
        private const long MaxFileSize = 5 * 1024 * 1024; // 5 MB
        private const string FolderName = "profiles";

        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContext;

        public ImageService(
            IWebHostEnvironment env,
            IHttpContextAccessor httpContext)
        {
            _env = env;
            _httpContext = httpContext;
        }

        public async Task<string> UploadProfileImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty.");

            if (!file.ContentType.StartsWith("image/"))
                throw new ArgumentException("Invalid file type.");

            if (file.Length > MaxFileSize)
                throw new ArgumentException("File too large.");

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            var folderPath = Path.Combine(
                _env.WebRootPath,
                "img",
                FolderName
            );

            Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            var request = _httpContext.HttpContext!.Request;
            return $"{request.Scheme}://{request.Host}/img/{FolderName}/{fileName}";
        }

        public Task DeleteProfileImageAsync(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
                return Task.CompletedTask;

            var fileName = Path.GetFileName(imageUrl);
            var filePath = Path.Combine(
                _env.WebRootPath,
                "img",
                FolderName,
                fileName
            );

            if (File.Exists(filePath))
                File.Delete(filePath);

            return Task.CompletedTask;
        }
    }
}
