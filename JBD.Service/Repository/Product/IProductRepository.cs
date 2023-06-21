using FluentResults;
using JBD.DATA.Models;
using JBD.ViewModel;
using Microsoft.AspNetCore.Http;

namespace JBD.Service.Repository;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<List<ProductVM>> GetProductListByUserIdAsync(int userRegistrationId);
    Task<ProductVM> GetProductByUserIdAsync(int userRegistrationId, int productId);
    Task DeleteProductImagesAsync(int userRegistrationId, int productId, List<int>  productImageIds);
    Task DeleteProductAsync(int userRegistrationId, int productId);
    Task UpdateProductAsync(int userRegistrationId, ProductUpdateVM productVm);
    Task AddProductImageAsync(int userRegistrationId, int productId, IFormFile file);

}