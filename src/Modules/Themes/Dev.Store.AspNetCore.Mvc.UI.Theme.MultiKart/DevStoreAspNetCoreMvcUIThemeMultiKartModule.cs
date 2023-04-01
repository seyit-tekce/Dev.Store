using Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart.Bundling;
using Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart.Toolbars;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart;

[DependsOn(
    typeof(AbpAspNetCoreMvcUiThemeSharedModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule)
    )]
public class DevStoreAspNetCoreMvcUIThemeMultiKartModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(DevStoreAspNetCoreMvcUIThemeMultiKartModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpThemingOptions>(options =>
        {
            options.Themes.Add<MultikartTheme>();

            if (options.DefaultThemeName == null)
            {
                options.DefaultThemeName = MultikartTheme.Name;
            }
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<DevStoreAspNetCoreMvcUIThemeMultiKartModule>("Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart");
        });

        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new MultikartThemeMainTopToolbarContributor());
        });

        Configure<AbpBundlingOptions>(options =>
        {
            options
                .StyleBundles
                .Add(MultikartThemeBundles.Styles.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(StandardBundles.Styles.Global)
                        .AddContributors(typeof(MultikartThemeGlobalStyleContributor));
                });

            options
                .ScriptBundles
                .Add(MultikartThemeBundles.Scripts.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(StandardBundles.Scripts.Global)
                        .AddContributors(typeof(MultikartThemeGlobalScriptContributor));
                });
        });
    }
}
