using Dev.Store.Dtos;
using Dev.Store.Web.Pages.Dev.Store.Brand.ViewModels;
using AutoMapper;

namespace Dev.Store.Web;

public class StoreWebAutoMapperProfile : Profile
{
    public StoreWebAutoMapperProfile()
    {
   
        CreateMap<BrandDto, CreateEditBrandViewModel>();
        CreateMap<CreateEditBrandViewModel, CreateUpdateBrandDto>();
    }
}
