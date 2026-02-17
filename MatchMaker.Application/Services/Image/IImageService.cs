using Microsoft.AspNetCore.Http;

namespace MatchMaker.Application.Services.Image
{
    public interface IImageService
    {
        Task<string> UploadProfileImageAsync(IFormFile file);
        Task DeleteProfileImageAsync(string imageUrl);
    }
}
