using Microsoft.AspNetCore.Http;

namespace JBD.Service;

public interface IImageStorageService
{
    Task<string> SaveImageAsync(IFormFile file);
    Task DeleteImageAsync(string fileName);
}