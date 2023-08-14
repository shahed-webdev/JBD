using JBD.DATA.Models;
using JBD.ViewModel;

namespace JBD.Service.Repository;

public interface ISettingShippingFeeRatioRepository:IBaseRepository<SettingShippingFeeRatio>
{
    Task<List<SettingShippingFeeRatioVM>> GetSettingShippingFeeRatioListAsync(int userRegistrationId);
    Task<SettingShippingFeeRatioVM> GetSettingShippingFeeRatioAsync(int userRegistrationId, int settingShippingFeeRatioId);
    Task<decimal> GetSettingShippingFeeRatioByMeasurementAsync(int userRegistrationId, decimal size, decimal weight);
    Task AddSettingShippingFeeRatioAsync(int userRegistrationId, SettingShippingFeeRatioVM model);
    Task UpdateSettingShippingFeeRatioAsync(int userRegistrationId, SettingShippingFeeRatioVM model);
    Task DeleteSettingShippingFeeRatioAsync(int userRegistrationId, int settingShippingFeeRatioId);
    Task<bool> IsSizeExistAsync(int userRegistrationId, decimal size);
    Task<bool> IsWeightExistAsync(int userRegistrationId, decimal weight);
}