using AutoMapper;
using Dev.Store.Address.Dtos;
using Dev.Store.Brands;
using Dev.Store.Brands.Dtos;
using Dev.Store.Categories;
using Dev.Store.Categories.Dtos;
using Dev.Store.HomeSliders;
using Dev.Store.HomeSliders.Dtos;
using Dev.Store.Keywords;
using Dev.Store.Keywords.Dtos;
using Dev.Store.Locations;
using Dev.Store.Locations.Dtos;
using Dev.Store.OrderActions;
using Dev.Store.OrderActions.Dtos;
using Dev.Store.OrderAddress;
using Dev.Store.OrderAddress.Dtos;
using Dev.Store.OrderProducts;
using Dev.Store.OrderProducts.Dtos;
using Dev.Store.Orders;
using Dev.Store.Orders.Dtos;
using Dev.Store.OrderSets;
using Dev.Store.OrderSets.Dtos;
using Dev.Store.OrderSizes;
using Dev.Store.OrderSizes.Dtos;
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
using Dev.Store.CartProducts;
using Dev.Store.CartProducts.Dtos;
using Dev.Store.CartSets;
using Dev.Store.CartSets.Dtos;
using Dev.Store.CartSizes;
using Dev.Store.CartSizes.Dtos;
using System.Linq;
using System.Collections.Generic;

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
            .ForMember(x => x.Price, x => x.MapFrom(a => (a.ProductSets != null ? a.ProductSets.Where(b => !b.IsOptional).Sum(b => b.Price) : 0) + (a.ProductSizes != null ? a.ProductSizes.Where(b => b.IsDefault).Sum(b => b.Price) : 0)))
            .ForMember(x => x.CategoryName, x => x.MapFrom(a => a.Category.Name))
            .ForMember(x => x.CategoryLink, x => x.MapFrom(a => a.Category.Link))
            .ForMember(x => x.ParentCategoryLink, x => x.MapFrom(a => a.Category.CategoryParent.Link))
            .ForMember(x => x.MainImagePath, x => x.MapFrom(a => a.ProductImages.FirstOrDefault(b => b.IsMain || true).UploadFile.Medium()))
            .ForMember(x => x.SecondImagePath, x => x.MapFrom(a => a.ProductImages.FirstOrDefault(b => !b.IsMain).UploadFile.Medium()));

        CreateMap<HomeSlider, HomeSliderDto>();
        CreateMap<CreateUpdateHomeSliderDto, HomeSlider>(MemberList.Source);
        CreateMap<Order, OrderDto>();
        CreateMap<CreateUpdateOrderDto, Order>(MemberList.Source);
        CreateMap<OrderAction, OrderActionDto>();
        CreateMap<CreateUpdateOrderActionDto, OrderAction>(MemberList.Source);
        CreateMap<OrderAdress, OrderAdressDto>();
        CreateMap<CreateUpdateOrderAdressDto, OrderAdress>(MemberList.Source);
        CreateMap<OrderProduct, OrderProductDto>();
        CreateMap<CreateUpdateOrderProductDto, OrderProduct>(MemberList.Source);
        CreateMap<OrderSet, OrderSetDto>();
        CreateMap<CreateUpdateOrderSetDto, OrderSet>(MemberList.Source);
        CreateMap<OrderSize, OrderSizeDto>();
        CreateMap<CreateUpdateOrderSizeDto, OrderSize>(MemberList.Source);
        CreateMap<Address.Address, AddressDto>();
        CreateMap<CreateUpdateAddressDto, Address.Address>(MemberList.Source);
        CreateMap<CartProduct, CartProductDto>();
        CreateMap<CreateUpdateCartProductDto, CartProduct>(MemberList.Source);
        CreateMap<CartSet, CartSetDto>();
        CreateMap<CreateUpdateCartSetDto, CartSet>(MemberList.Source);
        CreateMap<CartSize, CartSizeDto>();
        CreateMap<CreateUpdateCartSizeDto, CartSize>(MemberList.Source);

        CreateMap<CartProduct, CartProductListDto>()
            .ForMember(x => x.MainImagePath, x => x.MapFrom(a => a.Product.ProductImages.FirstOrDefault(b => b.IsMain || true).UploadFile.Medium()))
            .ForMember(x => x.Name, x => x.MapFrom(x => x.Product.Name))
            .ForMember(x => x.Code, x => x.MapFrom(x => x.Product.Code))
            .ForMember(x => x.Price, x => x.MapFrom(x => x.Product.Price));

        CreateMap<IEnumerable<CartProduct>, CartDto>().ForMember(x => x.Products, x => x.MapFrom(a => a));
    }
}
