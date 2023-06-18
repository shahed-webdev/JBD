using Microsoft.AspNetCore.Http;

namespace JBD.Service;

public class LocalStorageImageStorageService : IImageStorageService
{
    private readonly string _storagePath;

    public LocalStorageImageStorageService()
    { 
        _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
    }

    public LocalStorageImageStorageService(string storagePath)
    {
        _storagePath = storagePath;
    }

    public async Task<string> SaveImageAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("Invalid file.");
        }

        var fileName = Guid.NewGuid().ToString();
        var filePath = Path.Combine(_storagePath, fileName);

        try
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
        catch (Exception ex)
        {
            // Handle exception, log error, etc.
            throw new Exception("Failed to save the image.", ex);
        }
    }

    public Task DeleteImageAsync(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentException("Invalid file name.");
        }

        var filePath = Path.Combine(_storagePath, fileName);

        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            // Handle exception, log error, etc.
            throw new Exception("Failed to delete the image.", ex);
        }
    }
}