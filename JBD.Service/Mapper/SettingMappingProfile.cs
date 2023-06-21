using AutoMapper;
using JBD.DATA.Models;
using JBD.ViewModel;

namespace JBD.Service;

public class SettingMappingProfile: Profile
{
    public SettingMappingProfile()
    {
        CreateMap<SettingProfitAmazon, SettingProfitAmazonVM>().ReverseMap();
        CreateMap<SettingProfitRatio, SettingProfitRatioVM>().ReverseMap();
        CreateMap<SettingShippingFeeRatio, SettingShippingFeeRatioVM>().ReverseMap();
    }
    
}