using AutoMapper;
using Dev.Store.Brands;
using Dev.Store.Brands.Dtos;
using Dev.Store.Categories;
using Dev.Store.Categories.Dtos;
using Dev.Store.Keywords;
using Dev.Store.Keywords.Dtos;
using Dev.Store.Locations;
using Dev.Store.UploadFiles;
using Dev.Store.UploadFiles.Dtos;
using Dev.Store.Products;
using Dev.Store.Products.Dtos;
using Dev.Store.ProductSets;
using Dev.Store.ProductSets.Dtos;
using Dev.Store.ProductSizes;
using Dev.Store.ProductSizes.Dtos;
using Dev.Store.SeoSettings;
using Dev.Store.SeoSettings.Dtos;
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
        CreateMap<Category, CategoryListDto>();
        CreateMap<CreateUpdateCategoryDto, Category>(MemberList.Source);


        CreateMap<Location, LocationDto>();
        CreateMap<CreateUpdateLocationDto, Location>(MemberList.Source);
        CreateMap<Keyword, KeywordDto>();
        CreateMap<CreateUpdateKeywordDto, Keyword>(MemberList.Source);


        CreateMap<UploadFile, UploadFileDto>();
        CreateMap<CreateUpdateUploadFileDto, UploadFile>(MemberList.Source);
        CreateMap<Product, ProductDto>();
        CreateMap<Product, ProductListDto>();
        CreateMap<CreateUpdateProductDto, Product>(MemberList.Source);
        CreateMap<ProductSet, ProductSetDto>();
        CreateMap<CreateUpdateProductSetDto, ProductSet>(MemberList.Source);
        CreateMap<ProductSize, ProductSizeDto>();
        CreateMap<CreateUpdateProductSizeDto, ProductSize>(MemberList.Source);
        CreateMap<SeoSetting, SeoSettingDto>();
        CreateMap<CreateUpdateSeoSettingDto, SeoSetting>(MemberList.Source);
    }
}
