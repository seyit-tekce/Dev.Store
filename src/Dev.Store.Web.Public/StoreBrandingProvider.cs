using Dev.Store.Settings;
using Dev.Store.Web.UI.Branding;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Dev.Store.Web.Public;

[Dependency(ReplaceServices = true)]
public class StoreBrandingProvider : IDevBrandingProvider, ITransientDependency
{
    private readonly ISiteSettingAppService _siteSettingAppService;
    private SiteSettingDto SiteSettings { get; }

    public StoreBrandingProvider(ISiteSettingAppService siteSettingAppService)
    {
        _siteSettingAppService = siteSettingAppService;
        SiteSettings = _siteSettingAppService.GetAsync().Result;
    }

    public string AppName => SiteSettings.SiteSettingTitle;
    public string LogoUrl => SiteSettings.SiteSettingLogo;
    public string LogoReverseUrl => SiteSettings.SiteSettingLogoReverse;
    public string SiteIcon => SiteSettings.SiteSettingIcon;
    public string SiteDescription => SiteSettings.SiteSettingDescription;
}
