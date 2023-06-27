using Dev.Store.Address;
using Dev.Store.OrderSizes;
using Dev.Store.OrderSets;
using Dev.Store.OrderProducts;
using Dev.Store.OrderAddress;
using Dev.Store.OrderActions;
using Dev.Store.Orders;
using Dev.Store.HomeSliders;
using Dev.Store.Brands;
using Dev.Store.Categories;
using Dev.Store.Keywords;
using Dev.Store.Locations;
using Dev.Store.ProductImages;
using Dev.Store.Products;
using Dev.Store.ProductSets;
using Dev.Store.ProductSizes;
using Dev.Store.SeoSettings;
using Dev.Store.UploadFiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.CmsKit.EntityFrameworkCore;
namespace Dev.Store.EntityFrameworkCore;

[DependsOn(
    typeof(StoreDomainModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCorePostgreSqlModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule)
    )]
[DependsOn(typeof(BlobStoringDatabaseEntityFrameworkCoreModule))]
[DependsOn(typeof(CmsKitEntityFrameworkCoreModule))]
public class StoreEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        StoreEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<StoreDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
            options.AddRepository<Brand, BrandRepository>();
            options.AddRepository<Category, CategoryRepository>();
            options.AddRepository<Location, LocationRepository>();
            options.AddRepository<Keyword, KeywordRepository>();
            options.AddRepository<UploadFile, UploadFileRepository>();
            options.AddRepository<Product, ProductRepository>();
            options.AddRepository<ProductSet, ProductSetRepository>();
            options.AddRepository<ProductSize, ProductSizeRepository>();
            options.AddRepository<SeoSetting, SeoSettingRepository>();
            options.AddRepository<ProductImage, ProductImageRepository>();
            options.AddRepository<HomeSlider, HomeSliderRepository>();
            options.AddRepository<Order, OrderRepository>();
            options.AddRepository<OrderAction, OrderActionRepository>();
            options.AddRepository<OrderAdress, OrderAdressRepository>();
            options.AddRepository<OrderProduct, OrderProductRepository>();
            options.AddRepository<OrderSet, OrderSetRepository>();
            options.AddRepository<OrderSize, OrderSizeRepository>();
            options.AddRepository<Address.Address, AddressRepository>();
        });

        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also StoreMigrationsDbContextFactory for EF Core tooling. */
            options.UseNpgsql();

        });

    }
}
