using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Dev.Store.Web;

[Dependency(ReplaceServices = true)]
public class StoreBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Store";
}
