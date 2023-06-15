using JBD.Service.Repository;
using JBD.ViewModel;

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
    public async Task<List<ProductVM>> FetchProductsAsync(string userName)
    {
        var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);
        var products = await _productRepository.GetProductListByUserId(userId);
        return products;
    }
}