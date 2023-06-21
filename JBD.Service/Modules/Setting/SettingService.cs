using FluentResults;
using JBD.DATA.Enums;
using JBD.DATA.Models;
using JBD.Service.Repository;
using JBD.ViewModel;

namespace JBD.Service.Modules.Setting;

public class SettingService : ISettingService
{
    private readonly IUserRegistrationRepository _userRegistrationRepository;
    private readonly IExcludeKeywordRepository _excludeKeywordRepository;
    private readonly ISettingProfitAmazonRepository _settingProfitAmazonRepository;
    private readonly ISettingProfitRatioRepository _settingProfitRatioRepository;
    private readonly ISettingShippingFeeRatioRepository _settingShippingFeeRatioRepository;

    public SettingService(IUserRegistrationRepository userRegistrationRepository, IExcludeKeywordRepository excludeKeywordRepository, ISettingProfitRatioRepository settingProfitRatioRepository, ISettingProfitAmazonRepository settingProfitAmazonRepository, ISettingShippingFeeRatioRepository settingShippingFeeRatioRepository)
    {
        _userRegistrationRepository = userRegistrationRepository;
        _excludeKeywordRepository = excludeKeywordRepository;
        _settingProfitRatioRepository = settingProfitRatioRepository;
        _settingProfitAmazonRepository = settingProfitAmazonRepository;
        _settingShippingFeeRatioRepository = settingShippingFeeRatioRepository;
    }

    public async Task<Result<List<string>>> GetExcludeKeywordsByTypeAsync(string userName, ExcludeKeywordType type)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);
            
            if(userId==0) return Result.Fail<List<string>>($"Not a valid user");

            var keyWords = await _excludeKeywordRepository.GetAllByTypeAsync(userId, type);

            return Result.Ok(keyWords);
        }
        catch (Exception e)
        {
            return Result.Fail<List<string>>(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result> UpdateExcludeKeywordsByTypeAsync(string userName, ExcludeKeywordType type, List<string> keywords)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail($"Not a valid user");

            await _excludeKeywordRepository.DeleteKeywordsAsync(userId, type);

            await _excludeKeywordRepository.AddKeywordsAsync(userId, type, keywords);

            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }



    public async Task<Result<SettingProfitAmazonVM>> GetSettingProfitAmazonAsync(string userName)
    {

        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail($"Not a valid user");

            var settingAmazon = await _settingProfitAmazonRepository.GetSettingProfitAmazonAsync(userId);

            return Result.Ok(settingAmazon);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result> SetSettingProfitAmazonAsync(string userName, SettingProfitAmazonVM model)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail($"Not a valid user");

            await _settingProfitAmazonRepository.SetSettingProfitAmazonAsync(userId, model);

            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }


    public async Task<Result<List<SettingProfitRatioVM>>> GetSettingProfitRatioListAsync(string userName)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail<List<SettingProfitRatioVM>>($"Not a valid user");

            var list = await _settingProfitRatioRepository.GetSettingProfitRatioListAsync(userId);

            return Result.Ok(list);
        }
        catch (Exception e)
        {
            return Result.Fail<List<SettingProfitRatioVM>>(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<SettingProfitRatioVM>> GetSettingProfitRatioAsync(string userName, int settingProfitRatioId)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail<SettingProfitRatioVM>($"Not a valid user");

            var settingProfit = await _settingProfitRatioRepository.GetSettingProfitRatioAsync(userId, settingProfitRatioId);

            return Result.Ok(settingProfit);
        }
        catch (Exception e)
        {
            return Result.Fail<SettingProfitRatioVM>(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result> AddSettingProfitRatioAsync(string userName, SettingProfitRatioVM model)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail($"Not a valid user");

            await _settingProfitRatioRepository.AddSettingProfitRatioAsync(userId, model);

            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result> UpdateSettingProfitRatioAsync(string userName, SettingProfitRatioVM model)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail($"Not a valid user");

            await _settingProfitRatioRepository.UpdateSettingProfitRatioAsync(userId, model);

            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result> DeleteSettingProfitRatioAsync(string userName, int settingProfitRatioId)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail($"Not a valid user");

            await _settingProfitRatioRepository.DeleteSettingProfitRatioAsync(userId, settingProfitRatioId);

            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<List<SettingShippingFeeRatioVM>>> GetSettingShippingFeeRatioListAsync(string userName)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail<List<SettingShippingFeeRatioVM>>($"Not a valid user");

            var list = await _settingShippingFeeRatioRepository.GetSettingShippingFeeRatioListAsync(userId);

            return Result.Ok(list);
        }
        catch (Exception e)
        {
            return Result.Fail<List<SettingShippingFeeRatioVM>>(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<SettingShippingFeeRatioVM>> GetSettingShippingFeeRatioAsync(string userName, int settingShippingFeeRatioId)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail<SettingShippingFeeRatioVM>($"Not a valid user");

            var settingProfit = await _settingShippingFeeRatioRepository.GetSettingShippingFeeRatioAsync(userId, settingShippingFeeRatioId);

            return Result.Ok(settingProfit);
        }
        catch (Exception e)
        {
            return Result.Fail<SettingShippingFeeRatioVM>(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result> AddSettingShippingFeeRatioAsync(string userName, SettingShippingFeeRatioVM model)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail($"Not a valid user");

            await _settingShippingFeeRatioRepository.AddSettingShippingFeeRatioAsync(userId, model);

            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result> UpdateSettingShippingFeeRatioAsync(string userName, SettingShippingFeeRatioVM model)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail($"Not a valid user");

            await _settingShippingFeeRatioRepository.UpdateSettingShippingFeeRatioAsync(userId, model);

            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result> DeleteSettingShippingFeeRatioAsync(string userName, int settingShippingFeeRatioId)
    {
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail($"Not a valid user");

            await _settingShippingFeeRatioRepository.DeleteSettingShippingFeeRatioAsync(userId, settingShippingFeeRatioId);

            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<decimal>> CalculatePriceWithProfitAsync(string userName, decimal price, decimal size, decimal weight)
    {
        // (AmazonPrice + PlusAmount - MinusAmount) + (AmazonPrice * Commission%) + Expense  + shippingFee
        // if ProfitAmount added = Must be that amount will be profit (AmazonPrice + (AmazonPrice * Commission%) + Expense  + shippingFee + ProfitAmount)
        try
        {
            var userId = await _userRegistrationRepository.GetUserRegistrationIdByUserNameAsync(userName);

            if (userId == 0) return Result.Fail<decimal>($"Not a valid user");

            var amazonSetting = await _settingProfitAmazonRepository.GetSettingProfitAmazonAsync(userId);

            var settingProfitRatio = await _settingProfitRatioRepository.GetSettingProfitRatioByPriceAsync(userId, price);

            var shippingFee = await _settingShippingFeeRatioRepository.GetSettingShippingFeeRatioByMeasurementAsync(userId, size, weight);

            var commissionAmount = price * (amazonSetting.Commission / 100);



            var priceWithProfit = price * (settingProfitRatio.PercentageWithPriceAndProfit / 100) + settingProfitRatio.PlusAmount - settingProfitRatio.MinusAmount + commissionAmount + amazonSetting.Expense + shippingFee;

            if (settingProfitRatio.ProfitAmount != 0)
            {
                priceWithProfit = price + commissionAmount + amazonSetting.Expense + shippingFee + settingProfitRatio.ProfitAmount;
            }

            return Result.Ok(priceWithProfit);
        }
        catch (Exception e)
        {
            return Result.Fail<decimal>(e.InnerException?.Message ?? e.Message);
        }
    }
}