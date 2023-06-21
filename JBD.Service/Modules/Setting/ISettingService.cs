﻿using FluentResults;
using JBD.DATA.Enums;
using JBD.ViewModel;

namespace JBD.Service.Modules.Setting;

public interface ISettingService
{
    Task<Result<List<string>>> GetExcludeKeywordsByTypeAsync(string userName, ExcludeKeywordType type);
    Task<Result> UpdateExcludeKeywordsByTypeAsync(string userName, ExcludeKeywordType type, List<string> keywords);
  
    Task<Result<SettingProfitAmazonVM>> GetSettingProfitAmazonAsync(string userName);
    Task<Result> SetSettingProfitAmazonAsync(string userName, SettingProfitAmazonVM model);

    //-------------SettingProfitRatio--------
    Task<Result<List<SettingProfitRatioVM>>> GetSettingProfitRatioListAsync(string userName);
    Task<Result<SettingProfitRatioVM>> GetSettingProfitRatioAsync(string userName, int settingProfitRatioId);
    Task<Result> AddSettingProfitRatioAsync(string userName, SettingProfitRatioVM model);
    Task<Result> UpdateSettingProfitRatioAsync(string userName, SettingProfitRatioVM model);
    Task<Result> DeleteSettingProfitRatioAsync(string userName, int settingProfitRatioId);


    //-------------SettingShippingFeeRatio--------
    Task<Result<List<SettingShippingFeeRatioVM>>> GetSettingShippingFeeRatioListAsync(string userName);
    Task<Result<SettingShippingFeeRatioVM>> GetSettingShippingFeeRatioAsync(string userName, int settingShippingFeeRatioId);
    Task<Result> AddSettingShippingFeeRatioAsync(string userName, SettingShippingFeeRatioVM model);
    Task<Result> UpdateSettingShippingFeeRatioAsync(string userName, SettingShippingFeeRatioVM model);
    Task<Result> DeleteSettingShippingFeeRatioAsync(string userName, int settingShippingFeeRatioId);

    Task<Result<decimal>> CalculatePriceWithProfitAsync(string userName, decimal price, decimal size, decimal weight);
}