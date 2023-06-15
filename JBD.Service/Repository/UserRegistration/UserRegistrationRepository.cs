using JBD.DATA;
using JBD.DATA.Models;
using Microsoft.EntityFrameworkCore;

namespace JBD.Service.Repository;

public class UserRegistrationRepository:BaseRepository<UserRegistration>, IUserRegistrationRepository
{
    public UserRegistrationRepository(ApplicationDbContext context) : base(context)
    {

    }
    
    public async Task<int> GetUserRegistrationIdByUserNameAsync(string userName)
    {
        var user = await Context.UserRegistrations.FirstAsync(e => e.UserName == userName);
        return user.UserRegistrationId;
    }
}