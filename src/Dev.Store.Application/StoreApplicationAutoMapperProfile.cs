using AutoMapper;
using Dev.Store.Brands;
using Dev.Store.Brands.Dtos;
using Dev.Store.Categories;
using Dev.Store.Categories.Dtos;
using Dev.Store.Keywords;
using Dev.Store.Keywords.Dtos;
using Dev.Store.Locations;
using Dev.Store.Locations.Dtos;
using Dev.Store.ProductImages;
using Dev.Store.ProductImages.Dtos;
using Dev.Store.Products;
using Dev.Store.Products.Dtos;
using Dev.Store.ProductSets;
using Dev.Store.ProductSets.Dtos;
using Dev.Store.ProductSizes;
using Dev.Store.ProductSizes.Dtos;
using Dev.Store.SeoSettings;
using Dev.Store.SeoSettings.Dtos;
using Dev.Store.UploadFiles;
using Dev.Store.UploadFiles.Dtos;
using System.Linq;

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
        CreateMap<ProductImage, ProductImageDto>();
        CreateMap<CreateUpdateProductImageDto, ProductImage>(MemberList.Source);

        CreateMap<Product, ProductGridListDto>()
            .ForMember(x => x.BrandName, x => x.MapFrom(a => a.Brand.Name))
            .ForMember(x => x.CategoryName, x => x.MapFrom(a => a.Category.Name))
            .ForMember(x => x.CategoryLink, x => x.MapFrom(a => a.Category.Link))
            .ForMember(x => x.ParentCategoryLink, x => x.MapFrom(a => a.Category.CategoryParent.Link))
            .ForMember(x => x.MainImagePath, x => x.MapFrom(a => a.ProductImages.FirstOrDefault(b => b.IsMain || true).UploadFile.Medium()))
            .ForMember(x => x.SecondImagePath, x => x.MapFrom(a => a.ProductImages.FirstOrDefault(b => !b.IsMain).UploadFile.Medium()));

    }
}
