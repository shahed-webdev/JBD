using FluentResults;
using JBD.ViewModel;
using Microsoft.AspNetCore.Http;

namespace JBD.Service;

public interface IProductService
{
    public Task<Result<List<ProductVM>>> FetchProductsAsync(string userName);
    public Task<Result<ProductVM>> GetProductByUserIdAsync(string userName, int productId);
    public Task<Result> DeleteProductImagesAsync(string userName, int productId, List<int> productImageIds);
    public Task<Result> DeleteProductAsync(string userName, int productId);
    public Task<Result> UpdateProductAsync(string userName, ProductUpdateVM productVm);
    public Task<Result> AddProductImageAsync(string userName, int productId, IFormFile file);
}