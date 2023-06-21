using AutoMapper;
using AutoMapper.QueryableExtensions;
using JBD.DATA;
using JBD.DATA.Models;
using JBD.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace JBD.Service.Repository;

public class SettingProfitRatioRepository:BaseRepository<SettingProfitRatio>,ISettingProfitRatioRepository
{
    private readonly IMapper _mapper;
    public SettingProfitRatioRepository(ApplicationDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }
    private async Task<SettingProfitRatio> GetSettingAsync(int userRegistrationId, int settingProfitRatioId)
    {
        var settingProfit = await Context.SettingProfitRatios
            .Where(e => e.SettingProfitRatioId == settingProfitRatioId && e.UserRegistrationId == userRegistrationId)
            .FirstAsync();

        return settingProfit;

    }

    public async Task<List<SettingProfitRatioVM>> GetSettingProfitRatioListAsync(int userRegistrationId)
    {
        return await Context.SettingProfitRatios
            .Where(e => e.UserRegistrationId == userRegistrationId)
            .ProjectTo<SettingProfitRatioVM>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<SettingProfitRatioVM> GetSettingProfitRatioAsync(int userRegistrationId, int settingProfitRatioId)
    {
       var settingProfit = await GetSettingAsync(userRegistrationId, settingProfitRatioId);

       return _mapper.Map<SettingProfitRatioVM>(settingProfit);

    }

    public async Task<SettingProfitRatioVM> GetSettingProfitRatioByPriceAsync(int userRegistrationId, decimal price)
    {
        var settingProfit = await Context.SettingProfitRatios.OrderBy(e=> e.AmazonSellingPrice)
            .Where(e => e.AmazonSellingPrice >= price && e.UserRegistrationId == userRegistrationId)
            .FirstAsync();
        return _mapper.Map<SettingProfitRatioVM>(settingProfit);
    }


    public async Task AddSettingProfitRatioAsync(int userRegistrationId, SettingProfitRatioVM model)
    {
       var settingProfit = _mapper.Map<SettingProfitRatio>(model);
       settingProfit.UserRegistrationId = userRegistrationId;
       
       await Context.AddAsync(settingProfit);
       await Context.SaveChangesAsync();
    }

    public async Task UpdateSettingProfitRatioAsync(int userRegistrationId, SettingProfitRatioVM model)
    {
        var settingProfit = await GetSettingAsync(userRegistrationId, model.SettingProfitRatioId);

        settingProfit.PercentageWithPriceAndProfit = model.PercentageWithPriceAndProfit;
        settingProfit.AmazonSellingPrice = model.AmazonSellingPrice;
        settingProfit.PlusAmount = model.PlusAmount;
        settingProfit.ProfitAmount = model.ProfitAmount;
        settingProfit.MinusAmount = model.MinusAmount;

        await Context.SaveChangesAsync();

    }

    public async Task DeleteSettingProfitRatioAsync(int userRegistrationId, int settingProfitRatioId)
    {
        var settingProfit = await GetSettingAsync(userRegistrationId, settingProfitRatioId);

        Context.Remove(settingProfit);

       await Context.SaveChangesAsync();
    }
}