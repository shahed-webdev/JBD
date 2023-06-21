using AutoMapper;
using AutoMapper.QueryableExtensions;
using JBD.DATA;
using JBD.DATA.Models;
using JBD.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace JBD.Service.Repository;

public class ProductRepository: BaseRepository<Product>, IProductRepository
{
    private readonly IMapper _mapper;
    private readonly IImageStorageService _imageStorageService;
    public ProductRepository(ApplicationDbContext context, IMapper mapper, IImageStorageService imageStorageService) : base(context)
    {
        _mapper = mapper;
        _imageStorageService = imageStorageService;
    }

    public async Task<List<ProductVM>> GetProductListByUserIdAsync(int userRegistrationId)
    {
        var products = await Context.Products.Include(p=> p.ProductImageLinks).Where(p => p.UserRegistrationId == userRegistrationId).ProjectTo<ProductVM>(_mapper.ConfigurationProvider).ToListAsync();

      return products;
    }

    public async Task<ProductVM> GetProductByUserIdAsync(int userRegistrationId, int productId)
    {
        var product = await Context.Products
            .Where(p => p.UserRegistrationId == userRegistrationId && p.ProductId == productId).FirstAsync();

        return _mapper.Map<ProductVM>(product);
    }

    public async Task DeleteProductImagesAsync(int userRegistrationId, int productId, List<int> productImageIds)
    {
        var productImages = await Context.ProductImageLinks.Where(p =>
            p.Product.UserRegistrationId == userRegistrationId && p.ProductId == productId &&
            productImageIds.Contains(p.ProductImageLinkId)).ToListAsync();

        foreach (var imageLink in productImages)
        {
            await _imageStorageService.DeleteImageAsync(imageLink.ImageLink);
        }
        Context.RemoveRange(productImages);

      await  Context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int userRegistrationId, int productId)
    {
        var productImages = await Context.Products.Where(p =>
            p.UserRegistrationId == userRegistrationId && p.ProductId == productId).ToListAsync();

        Context.Remove(productImages);

        await Context.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(int userRegistrationId, ProductUpdateVM productVm)
    {
        var product = await Context.Products
            .Where(p => p.UserRegistrationId == userRegistrationId && p.ProductId == productVm.ProductId).FirstAsync();

        product.Option = productVm.Option;
        product.ProductInformation = productVm.ProductInformation;
        product.StoreCategory = productVm.StoreCategory;

        await Context.SaveChangesAsync();

    }

    public async Task AddProductImageAsync(int userRegistrationId, int productId, IFormFile file)
    {
      var imageFileName =  await _imageStorageService.SaveImageAsync(file);

      var productImage = new ProductImageLink
      {
          ProductId = productId,
          ImageLink = imageFileName

      };

      await Context.ProductImageLinks.AddAsync(productImage);
      await Context.SaveChangesAsync();
    }
}