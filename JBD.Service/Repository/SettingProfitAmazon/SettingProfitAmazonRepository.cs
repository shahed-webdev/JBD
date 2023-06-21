using AutoMapper;
using JBD.DATA;
using JBD.DATA.Models;
using JBD.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace JBD.Service.Repository;

public class SettingProfitAmazonRepository : BaseRepository<SettingProfitAmazon>, ISettingProfitAmazonRepository
{
    private readonly IMapper _mapper;
    public SettingProfitAmazonRepository(ApplicationDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public async Task<SettingProfitAmazonVM> GetSettingProfitAmazonAsync(int userRegistrationId)
    {
        var settingAmazon = await GetSettingProfitAmazon(userRegistrationId);
        
        return _mapper.Map<SettingProfitAmazonVM>(settingAmazon);
    }

    private async Task<SettingProfitAmazon> GetSettingProfitAmazon(int userRegistrationId)
    {
       return await Context.SettingProfitAmazons.Where(e => e.UserRegistrationId == userRegistrationId).FirstAsync();
    }

    public async Task SetSettingProfitAmazonAsync(int userRegistrationId, SettingProfitAmazonVM model)
    {
        var settingAmazon = await GetSettingProfitAmazon(userRegistrationId);

        if (settingAmazon == null)
        {
            var newSettingAmazon = _mapper.Map<SettingProfitAmazon>(model);
            await Context.SettingProfitAmazons.AddAsync(newSettingAmazon);
        }
        else
        {
            settingAmazon.Expense = model.Expense;
            settingAmazon.Commission = model.Commission;
            settingAmazon.MinimumShippingFee = model.MinimumShippingFee;
            settingAmazon.ShippingUnitPrice = model.ShippingUnitPrice;
        }

        await Context.SaveChangesAsync();
    }
}