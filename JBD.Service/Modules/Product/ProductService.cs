using FluentResults;
using JBD.Service.Repository;
using JBD.ViewModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace JBD.Service;

public class ProductService: IProductService
{
    private readonly IUserRegistrationRepository _userRegistrationRepository;
    private readonly IProductRepository _productRepository;
    public ProductService(IUserRegistrationRepository userRegistrationRepository, IProductRepository productRepository)
    {
        _userRegistrationRepository = userRegistrationRepository;
        _productRepository = productRepository;
    }
    public async Task<Result<List<ProductVM>>> FetchProductsAsync(string userName)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail<List<ProductVM>> ($"Not a valid user");

            var products = await _productRepository.GetProductListByUserIdAsync(userId);
            return Result.Ok(products);
        }
        catch (Exception e)
        {
            return Result.Fail<List<ProductVM>>(e.InnerException?.Message ?? e.Message);
        }
        
    }

    public async Task<Result<ProductVM>> GetProductByUserIdAsync(string userName, int productId)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail<ProductVM>($"Not a valid user");

            var product = await _productRepository.GetProductByUserIdAsync(userId, productId);
            return Result.Ok(product);
        }
        catch (Exception e)
        {
            return Result.Fail<ProductVM>(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result> DeleteProductImagesAsync(string userName, int productId, List<int> productImageIds)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail($"Not a valid user");

            await _productRepository.DeleteProductImagesAsync(userId, productId, productImageIds);
            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result> DeleteProductAsync(string userName, int productId)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail($"Not a valid user");

            await _productRepository.DeleteProductAsync(userId, productId);
            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result> UpdateProductAsync(string userName, ProductUpdateVM productVm)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail($"Not a valid user");

            await _productRepository.UpdateProductAsync(userId, productVm);
            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result> AddProductImageAsync(string userName, int productId, IFormFile file)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail($"Not a valid user");

            await _productRepository.AddProductImageAsync(userId, productId, file);
            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }
}