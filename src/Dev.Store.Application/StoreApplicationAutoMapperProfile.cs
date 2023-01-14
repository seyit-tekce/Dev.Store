using AutoMapper;
using Dev.Store.Brands;
using Dev.Store.Brands.Dtos;
using Dev.Store.Categories;
using Dev.Store.Categories.Dtos;
using Dev.Store.Keywords;
using Dev.Store.Keywords.Dtos;
using Dev.Store.Locations;
using Dev.Store.Locations.Dtos;

namespace Dev.Store;

public class StoreApplicationAutoMapperProfile : Profile
{
    public StoreApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Brand, BrandDto>();
        CreateMap<CreateUpdateBrandDto, Brand>(MemberList.Source);
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateUpdateCategoryDto, Category>(MemberList.Source);
        CreateMap<Location, LocationDto>();
        CreateMap<CreateUpdateLocationDto, Location>(MemberList.Source);
        CreateMap<Keyword, KeywordDto>();
        CreateMap<CreateUpdateKeywordDto, Keyword>(MemberList.Source);
    }
}
