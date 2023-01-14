using AutoMapper;
using Dev.Store.Brands.Dtos;
using Dev.Store.Categories.Dtos;
using Dev.Store.Keywords.Dtos;
using Dev.Store.Locations.Dtos;
using Dev.Store.Web.Pages.Dev.Store.Brand.ViewModels;
using Dev.Store.Web.Pages.Entities.Category.ViewModels;
using Dev.Store.Web.Pages.Keywords.ViewModels;
using Dev.Store.Web.Pages.Locations.ViewModels;

namespace Dev.Store.Web;

public class StoreWebAutoMapperProfile : Profile
{
    public StoreWebAutoMapperProfile()
    {

        CreateMap<BrandDto, CreateEditBrandViewModel>();
        CreateMap<CreateEditBrandViewModel, CreateUpdateBrandDto>();

        CreateMap<CategoryDto, CreateEditCategoryViewModel>();
        CreateMap<CreateEditCategoryViewModel, CreateUpdateCategoryDto>();

        CreateMap<LocationDto, CreateEditLocationViewModel>();
        CreateMap<CreateEditLocationViewModel, CreateUpdateLocationDto>();

        CreateMap<KeywordDto, CreateEditKeywordViewModel>();
        CreateMap<CreateEditKeywordViewModel, CreateUpdateKeywordDto>();
    }
}
