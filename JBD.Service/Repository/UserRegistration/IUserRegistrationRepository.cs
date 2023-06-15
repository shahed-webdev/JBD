using JBD.DATA.Models;
namespace JBD.Service.Repository;

public interface IUserRegistrationRepository: IBaseRepository<UserRegistration>
{
    Task<int> GetUserRegistrationIdByUserNameAsync(string userName);
}