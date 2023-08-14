using FluentResults;
using JBD.DATA.Models;
using JBD.ViewModel;

namespace JBD.Service.Repository;

public interface ISettingProfitAmazonRepository : IBaseRepository<SettingProfitAmazon>
{
    Task<SettingProfitAmazonVM?> GetSettingProfitAmazonAsync(int userRegistrationId);
    Task SetSettingProfitAmazonAsync(int userRegistrationId, SettingProfitAmazonVM model);
}