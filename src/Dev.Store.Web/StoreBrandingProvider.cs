using Dev.Store.Settings;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Dev.Store.Web;

[Dependency(ReplaceServices = true)]
public class StoreBrandingProvider : DefaultBrandingProvider
{
    private readonly ISiteSettingAppService _siteSettingAppService;
    public StoreBrandingProvider(ISiteSettingAppService siteSettingAppService)
    {
        _siteSettingAppService = siteSettingAppService;
    }
    public override string AppName => _siteSettingAppService.GetAsync().GetAwaiter().GetResult().SiteSettingTitle;
    public override string LogoUrl => _siteSettingAppService.GetAsync().GetAwaiter().GetResult().SiteSettingLogo;
    public override string LogoReverseUrl => _siteSettingAppService.GetAsync().GetAwaiter().GetResult().SiteSettingLogoReverse;

}
