using AutoMapper;
using Dev.Store.Brands.Dtos;
using Dev.Store.Categories.Dtos;
using Dev.Store.HomeSliders.Dtos;
using Dev.Store.Keywords.Dtos;
using Dev.Store.Locations.Dtos;
using Dev.Store.Products.Dtos;
using Dev.Store.ProductSets.Dtos;
using Dev.Store.ProductSizes.Dtos;
using Dev.Store.SeoSettings;
using Dev.Store.Web.Pages.Dev.Store.Brand.ViewModels;
using Dev.Store.Web.Pages.Entities.Category.ViewModels;
using Dev.Store.Web.Pages.HomeSliders.ViewModels;
using Dev.Store.Web.Pages.Keywords.ViewModels;
using Dev.Store.Web.Pages.Locations.ViewModels;
using Dev.Store.Web.Pages.Products.Product.ViewModels;
using Dev.Store.Web.Pages.ProductSets.ViewModels;
using Dev.Store.Web.Pages.ProductSizes.ViewModels;
using Dev.Store.Web.Pages.SeoSettings.SeoSetting.ViewModels;

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
        CreateMap<CreateEditProductViewModel, CreateUpdateProductDto>();
        CreateMap<ProductDto, CreateEditProductViewModel>();
        CreateMap<CreateEditProductSizeViewModel, CreateUpdateProductSizeDto>();
        CreateMap<ProductSizeDto, CreateEditProductSizeViewModel>();
        CreateMap<CreateEditProductSetViewModel, CreateUpdateProductSetDto>();
        CreateMap<ProductSetDto, CreateEditProductSetViewModel>();
        CreateMap<SeoSetting, CreateEditSeoSettingViewModel>();
        CreateMap<CreateEditHomeSliderViewModel, CreateUpdateHomeSliderDto>();
        CreateMap<HomeSliderDto, CreateEditHomeSliderViewModel>();

    }
}