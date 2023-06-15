using AutoMapper;
using AutoMapper.QueryableExtensions;
using JBD.DATA;
using JBD.DATA.Models;
using JBD.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace JBD.Service.Repository;

public class ProductRepository: BaseRepository<Product>, IProductRepository
{
    private readonly IMapper _mapper;
    public ProductRepository(ApplicationDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public async Task<List<ProductVM>> GetProductListByUserId(int userRegistrationId)
    {
        var products = await Context.Products.Include(p=> p.ProductImageLinks).Where(p => p.UserRegistrationId == userRegistrationId).ProjectTo<ProductVM>(_mapper.ConfigurationProvider).ToListAsync();

      return products;
    }
}