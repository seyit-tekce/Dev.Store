
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.CmsKit;

namespace Dev.Store;

[DependsOn(
    typeof(StoreDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(StoreApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
[DependsOn(typeof(CmsKitApplicationModule))]
public class StoreApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<StoreApplicationModule>();
        });
        //context.Services.AddTransient<ICategoryRepository, CategoryRepository>();
        //context.Services.AddTransient<ISubCategoryRepository, SubCategoryRepository>();
        //context.Services.AddTransient<IProductRepository, ProductRepository>();
        //context.Services.AddTransient<ISetRepository, SetRepository>();
        //context.Services.AddTransient<ISizeRepository, SizeRepository>();
        //context.Services.AddTransient<IPhotoRepository, PhotoRepository>();
        //context.Services.AddTransient<ISeoSettingsRepository, SeoSettingsRepository>();
        //context.Services.AddTransient<IFeatureRepository, FeatureRepository>();




        //context.Services.AddDbContext<ProjectDbContext, MsDbContext>(ServiceLifetime.Transient);
    }
}
