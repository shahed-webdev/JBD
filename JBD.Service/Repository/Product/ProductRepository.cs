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
    public ProductRepository(ApplicationDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public async Task<List<ProductVM>> GetProductListByUserIdAsync(int userRegistrationId)
    {
        var products = await Context.Products.Include(p=> p.ProductImageLinks).Where(p => p.UserRegistrationId == userRegistrationId).ProjectTo<ProductVM>(_mapper.ConfigurationProvider).ToListAsync();

      return products;
    }

    public Task DeleteProductImagesAsync(int userRegistrationId, int productId, List<int> productImageIds)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProductAsync(int userRegistrationId, int productId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProductAsync(int userRegistrationId, ProductVM productVm)
    {
        throw new NotImplementedException();
    }

    public Task AddProductImageAsync(int userRegistrationId, IFormFile file)
    {
        throw new NotImplementedException();
    }
}