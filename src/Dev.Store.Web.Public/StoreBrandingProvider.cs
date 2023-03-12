using Dev.Store.Settings;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Dev.Store.Web.Public;

[Dependency(ReplaceServices = true)]
public class StoreBrandingProvider : DefaultBrandingProvider
{
    private readonly ISiteSettingAppService _siteSettingAppService;

    public StoreBrandingProvider(ISiteSettingAppService siteSettingAppService)
    {
        _siteSettingAppService = siteSettingAppService;
    }

    public override string AppName => _siteSettingAppService.GetAsync().Result.SiteSettingTitle;
    public override string LogoUrl => _siteSettingAppService.GetAsync().Result.SiteSettingLogo;
    public override string LogoReverseUrl => _siteSettingAppService.GetAsync().Result.SiteSettingLogoReverse;
    public string SiteIcon => _siteSettingAppService.GetAsync().Result.SiteSettingLogo;
    public string Catchword => _siteSettingAppService.GetAsync().Result.SiteSettingTitle;

}
