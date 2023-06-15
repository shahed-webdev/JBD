using JBD.DATA.Models;
using JBD.ViewModel;

namespace JBD.Service.Repository;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<List<ProductVM>> GetProductListByUserId(int userRegistrationId);
}