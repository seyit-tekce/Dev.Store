using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Dev.Store.Web;

[Dependency(ReplaceServices = true)]
public class StoreBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Yönetim Paneli";
    public override string LogoUrl => base.LogoUrl;
    public override string LogoReverseUrl => base.LogoReverseUrl;

}
