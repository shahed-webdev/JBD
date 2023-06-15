using JBD.ViewModel;

namespace JBD.Service;

public interface IProductService
{
    public Task<List<ProductVM>> FetchProductsAsync(string userName);
}