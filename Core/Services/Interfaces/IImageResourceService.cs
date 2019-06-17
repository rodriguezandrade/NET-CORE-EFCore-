
using Microsoft.AspNetCore.Http;

namespace Core.Services.Interfaces
{
    public interface IImageResourceService
    {
        bool canSaveImage(IFormFile imageFile, out string urlPath);
    }
}
