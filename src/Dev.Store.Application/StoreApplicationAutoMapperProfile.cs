using AutoMapper;
using Dev.Store;
using Dev.Store.Dtos;
using Dev.Store.Entities;

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
    }
}
