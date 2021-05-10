using AutoMapper;
using InventoryManagement.Models;

namespace InventoryManagement.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>()
                .ForPath(dest=>dest.Category.Name,opt=>opt.MapFrom(src=>src.CategoryName))
                .ForPath(dest=>dest.Brand.Id,opt=>opt.MapFrom(src=>src.BrandId));
        }
    }
}
