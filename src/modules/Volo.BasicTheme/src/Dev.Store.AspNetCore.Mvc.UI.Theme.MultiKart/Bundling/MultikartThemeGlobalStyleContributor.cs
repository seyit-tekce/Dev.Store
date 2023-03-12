using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart.Bundling;

public class MultikartThemeGlobalStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/assets/css/vendors/font-awesome.css");
        context.Files.Add("/assets/css/vendors/slick.css");
        context.Files.Add("/assets/css/vendors/slick-theme.css");
        context.Files.Add("/assets/css/vendors/animate.css");
        context.Files.Add("/assets/css/vendors/themify-icons.css");
        context.Files.Add("/assets/css/style.css");
    }
}
