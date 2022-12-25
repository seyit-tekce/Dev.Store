using Dev.Store.Dtos;
using Dev.Store.Web.Pages.Dev.Store.Brand.ViewModels;
using Dev.Store.Entities.Dtos;
using Dev.Store.Web.Pages.Entities.Category.ViewModels;
using AutoMapper;

namespace Dev.Store.Web;

public class StoreWebAutoMapperProfile : Profile
{
    public StoreWebAutoMapperProfile()
    {
   
        CreateMap<BrandDto, CreateEditBrandViewModel>();
        CreateMap<CreateEditBrandViewModel, CreateUpdateBrandDto>();
        CreateMap<CategoryDto, CreateEditCategoryViewModel>();
        CreateMap<CreateEditCategoryViewModel, CreateUpdateCategoryDto>();
    }
}
