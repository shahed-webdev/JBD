using AutoMapper;
using JBD.DATA.Models;
using JBD.ViewModel;

namespace JBD.Service;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductVM>()
            .ForMember(d => d.ImageLink, opt => opt.MapFrom(c => c.ProductImageLinks.First().ImageLink))
            .ReverseMap();
    }
}