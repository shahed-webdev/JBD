﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using JBD.DATA;
using JBD.DATA.Models;
using JBD.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace JBD.Service.Repository;

public class SettingShippingFeeRatioRepository:BaseRepository<SettingShippingFeeRatio>,ISettingShippingFeeRatioRepository
{
    private readonly IMapper _mapper;
    public SettingShippingFeeRatioRepository(ApplicationDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    private async Task<SettingShippingFeeRatio> GetSettingAsync(int userRegistrationId, int settingShippingFeeRatioId)
    {
        var settingProfit = await Context.SettingShippingFeeRatios
            .Where(e => e.SettingShippingFeeRatioId == settingShippingFeeRatioId && e.UserRegistrationId == userRegistrationId)
            .FirstAsync();

        return settingProfit;

    }

    public async Task<List<SettingShippingFeeRatioVM>> GetSettingShippingFeeRatioListAsync(int userRegistrationId)
    {
        return await Context.SettingShippingFeeRatios
            .Where(e => e.UserRegistrationId == userRegistrationId)
            .ProjectTo<SettingShippingFeeRatioVM>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<SettingShippingFeeRatioVM> GetSettingShippingFeeRatioAsync(int userRegistrationId, int SettingShippingFeeRatioId)
    {
        var settingProfit = await GetSettingAsync(userRegistrationId, SettingShippingFeeRatioId);

        return _mapper.Map<SettingShippingFeeRatioVM>(settingProfit);

    }

    public async Task<decimal> GetSettingShippingFeeRatioByMeasurementAsync(int userRegistrationId, decimal size, decimal weight)
    {
        var settingProfitBySize = await Context.SettingShippingFeeRatios.OrderBy(e=> e.Size)
            .Where(e => e.Size >= size && e.UserRegistrationId == userRegistrationId)
            .FirstAsync();
        var settingProfitByWeight = await Context.SettingShippingFeeRatios.OrderBy(e => e.Size)
            .Where(e => e.Weight >= weight && e.UserRegistrationId == userRegistrationId)
            .FirstAsync();

        var amount = settingProfitBySize.Amount > settingProfitByWeight.Amount
            ? settingProfitBySize.Amount
            : settingProfitByWeight.Amount;

        return amount;

    }


    public async Task AddSettingShippingFeeRatioAsync(int userRegistrationId, SettingShippingFeeRatioVM model)
    {
        var settingProfit = _mapper.Map<SettingShippingFeeRatio>(model);
        settingProfit.UserRegistrationId = userRegistrationId;

        await Context.AddAsync(settingProfit);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateSettingShippingFeeRatioAsync(int userRegistrationId, SettingShippingFeeRatioVM model)
    {
        var settingProfit = await GetSettingAsync(userRegistrationId, model.SettingShippingFeeRatioId);

       settingProfit.Amount = model.Amount;
       settingProfit.Size   = model.Size;
       settingProfit.Weight = model.Weight;

       await Context.SaveChangesAsync();

    }

    public async Task DeleteSettingShippingFeeRatioAsync(int userRegistrationId, int SettingShippingFeeRatioId)
    {
        var settingProfit = await GetSettingAsync(userRegistrationId, SettingShippingFeeRatioId);

        Context.Remove(settingProfit);

        await Context.SaveChangesAsync();
    }
}