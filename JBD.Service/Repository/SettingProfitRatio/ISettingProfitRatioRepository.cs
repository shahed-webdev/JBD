using FluentResults;
using JBD.DATA.Models;
using JBD.ViewModel;

namespace JBD.Service.Repository;

public interface ISettingProfitRatioRepository:IBaseRepository<SettingProfitRatio>
{
    Task<List<SettingProfitRatioVM>> GetSettingProfitRatioListAsync(int userRegistrationId);
    Task<SettingProfitRatioVM> GetSettingProfitRatioAsync(int userRegistrationId, int settingProfitRatioId);
    Task<SettingProfitRatioVM> GetSettingProfitRatioByPriceAsync(int userRegistrationId, decimal price);
    Task<bool> IsPriceExistAsync(int userRegistrationId, decimal price);
    Task AddSettingProfitRatioAsync(int userRegistrationId, SettingProfitRatioVM model);
    Task UpdateSettingProfitRatioAsync(int userRegistrationId, SettingProfitRatioVM model);
    Task DeleteSettingProfitRatioAsync(int userRegistrationId, int settingProfitRatioId);
}