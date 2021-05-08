using AutoMapper;
using InventoryManagement.Models;

namespace InventoryManagement.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>()
                .ForMember(dest=>dest.Category.Name,opt=>opt.MapFrom(src=>src.CategoryName))
                .ForMember(dest=>dest.Brand.Id,opt=>opt.MapFrom(src=>src.BrandId))
                .ForMember(dest=>dest.Brand.Id,opt=>opt.MapFrom(src=>src.BrandId));
        }
    }
}
