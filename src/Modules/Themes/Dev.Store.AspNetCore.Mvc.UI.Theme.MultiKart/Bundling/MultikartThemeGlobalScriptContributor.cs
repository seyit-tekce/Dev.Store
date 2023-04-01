using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart.Bundling;

public class MultikartThemeGlobalScriptContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/assets/js/slick.js");
        context.Files.Add("/assets/js/menu.js");
        context.Files.Add("/assets/js/lazysizes.min.js");
        context.Files.Add("/assets/js/bootstrap-notify.min.js");
        context.Files.Add("/assets/js/theme-setting.js");
        context.Files.Add("/assets/js/script.js");
        context.Files.Add("/themes/multikart/theme.js");

    }
}
