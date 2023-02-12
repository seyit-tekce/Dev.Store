using Dev.Store.EntityFrameworkCore;
using Dev.Store.Localization;
using Dev.Store.MultiTenancy;
using Dev.Store.Web.Menus;
using Dev.Store.Web.Settings;
using Dev.StoreAbp.Web.Bundling.Kendo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OpenIddict.Validation.AspNetCore;
using System;
using System.Globalization;
using System.IO;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.Database;
using Volo.Abp.Data;
using Volo.Abp.Identity.Web;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement.Web;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Volo.Abp.Swashbuckle;
using Volo.Abp.TenantManagement.Web;
using Volo.Abp.Ui.LayoutHooks;
using Volo.Abp.UI.Navigation;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileExplorer.Web;
using Volo.Abp.VirtualFileSystem;
using Volo.CmsKit.Web;

namespace Dev.Store.Web;

[DependsOn(
    typeof(StoreHttpApiModule),
    typeof(StoreApplicationModule),
    typeof(StoreEntityFrameworkCoreModule),
    typeof(AbpAutofacModule),
    typeof(AbpIdentityWebModule),
    typeof(AbpSettingManagementWebModule),
    typeof(AbpAccountWebOpenIddictModule),
    typeof(AbpAspNetCoreMvcUiLeptonXLiteThemeModule),
    typeof(AbpTenantManagementWebModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpVirtualFileExplorerWebModule)
    )]
[DependsOn(typeof(AbpVirtualFileExplorerWebModule))]
[DependsOn(typeof(CmsKitWebModule))]
public class StoreWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(
                typeof(StoreResource),
                typeof(StoreDomainModule).Assembly,
                typeof(StoreDomainSharedModule).Assembly,
                typeof(StoreApplicationModule).Assembly,
                typeof(StoreApplicationContractsModule).Assembly,
                typeof(StoreWebModule).Assembly
            );
        });

        PreConfigure<OpenIddictBuilder>(builder =>
        {
            builder.AddValidation(options =>
            {
                options.AddAudiences("Store");
                options.UseLocalServer();
                options.UseAspNetCore();
            });
        });
        Configure<AbpBlobStoringOptions>(options =>
        {
            options.Containers.ConfigureDefault(container =>
            {
                container.UseDatabase();
            });
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        ConfigureAuthentication(context);
        ConfigureUrls(configuration);
        ConfigureBundles();
        ConfigureAutoMapper();
        ConfigureVirtualFileSystem(hostingEnvironment);
        ConfigureNavigationServices();
        ConfigureAutoApiControllers();
        ConfigureSwaggerServices(context.Services);
        ConfigureKendo(context);
        ConfigureSerializers(context);
        ConfigureDatabaseConnections();
        ConfigureSettings();
        context.Services.AddResponseCompression(c =>
        {
            c.EnableForHttps = true;
        });
        Configure<AbpAntiForgeryOptions>(options =>
        {
            options.TokenCookie.Expiration = TimeSpan.FromDays(365);
        });
    }

    private void ConfigureAuthentication(ServiceConfigurationContext context)
    {
        context.Services.ForwardIdentityAuthenticationForBearer(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
    }


    private void ConfigureDatabaseConnections()
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.Databases.Configure("SaasService", database =>
            {
                database.MappedConnections.Add("Saas");
                database.IsUsedByTenants = false;
            });

            options.Databases.Configure("AdministrationService", database =>
            {
                database.MappedConnections.Add("AbpAuditLogging");
                database.MappedConnections.Add("AbpPermissionManagement");
                database.MappedConnections.Add("AbpSettingManagement");
                database.MappedConnections.Add("AbpFeatureManagement");
                database.MappedConnections.Add("AbpLanguageManagement");
                database.MappedConnections.Add("TextTemplateManagement");
                database.MappedConnections.Add("AbpBlobStoring");
            });

            options.Databases.Configure("IdentityService", database =>
            {
                database.MappedConnections.Add("AbpIdentity");
                database.MappedConnections.Add("OpenIddict");
            });

            options.Databases.Configure("ProductService", database =>
            {
                database.MappedConnections.Add("ProductService");
            });
        });
    }

    private void ConfigureUrls(IConfiguration configuration)
    {
        Configure<AppUrlOptions>(options =>
        {
            options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
        });
    }
    private void ConfigureSettings()
    {
        Configure<SettingManagementPageOptions>(options =>
        {
            options.Contributors.Add(new DevStoreSettingPageContributor());
        });
    }

    private void ConfigureBundles()
    {
        Configure<AbpBundlingOptions>(options =>
        {
            options
                .StyleBundles.Configure(
                    LeptonXLiteThemeBundles.Styles.Global,
                    bundle =>
                    {
                        bundle.AddFiles("/global-styles.css");
                    }
                )
                .Get(StandardBundles.Styles.Global)
                .AddContributors(typeof(KendoStyleContributor)); // add this
            options.ScriptBundles.Configure(LeptonXLiteThemeBundles.Scripts.Global, bundle =>
            {
                bundle.AddFiles("/custom-libs/jquery.livequery.min.js");
                bundle.AddFiles("/custom-libs/linq/jquery.linq.js");
                bundle.AddFiles("/kendo/js/kendo.all.min.js");
                bundle.AddFiles("/kendo/js/kendo.aspnetmvc.min.js");
                bundle.AddFiles("/kendo/js/jszip.min.js");
                bundle.AddFiles($"/kendo/js/cultures/kendo.culture.{CultureInfo.CurrentCulture.Name}-{CultureInfo.CurrentCulture.Name.ToUpper()}.min.js");
                bundle.AddFiles($"/kendo/js/messages/kendo.messages.{CultureInfo.CurrentCulture.Name}-{CultureInfo.CurrentCulture.Name.ToUpper()}.min.js");
                bundle.AddFiles("/custom/js/master.js");
            });
        });
        Configure<AbpLayoutHookOptions>(options =>
        {
            options.Add(
                LayoutHooks.Body.Last, //The hook name
                typeof(KendoViewComponent) //The component to add
            );
        });

    }
    private void ConfigureSerializers(ServiceConfigurationContext context)
    {
        context.Services.AddControllers(options => { }).AddJsonOptions(a =>
        {
            a.JsonSerializerOptions.Converters.Add(new Dev.Store.Infrastructure.Converter.Json.Microsoft.DataSourceResultConverter());
        });
    }
    private void ConfigureKendo(ServiceConfigurationContext context)
    {
        context.Services.AddKendo();
    }
    private void ConfigureAutoMapper()
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<StoreWebModule>();
        });
    }

    private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
    {
        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<StoreDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Dev.Store.Domain.Shared"));
                options.FileSets.ReplaceEmbeddedByPhysical<StoreDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Dev.Store.Domain"));
                options.FileSets.ReplaceEmbeddedByPhysical<StoreApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Dev.Store.Application.Contracts"));
                options.FileSets.ReplaceEmbeddedByPhysical<StoreApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Dev.Store.Application"));
                options.FileSets.ReplaceEmbeddedByPhysical<StoreWebModule>(hostingEnvironment.ContentRootPath);
            });
        }
    }

    private void ConfigureNavigationServices()
    {
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new StoreMenuContributor());
        });
    }

    private void ConfigureAutoApiControllers()
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(StoreApplicationModule).Assembly);
        });
    }

    private void ConfigureSwaggerServices(IServiceCollection services)
    {
        services.AddAbpSwaggerGen(
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Store API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            }
        );
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();

        if (!env.IsDevelopment())
        {
            app.UseErrorPage();
        }

        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAbpOpenIddictValidation();

        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }

        app.UseUnitOfWork();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Store API");
        });
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}
