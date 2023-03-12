using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Bundling;

public class BasicThemeGlobalScriptContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.RemoveAll(x => 1 == 1);
        context.Files.Add("/themes/shop/js/isotope.pkgd.min.js");
        context.Files.Add("/themes/shop/js/owl.carousel.min.js");
        context.Files.Add("/themes/shop/js/jquery.fitvids.js");
        context.Files.Add("/themes/shop/js/sticky-kit.min.js");
        context.Files.Add("/themes/shop/js/photoswipe.min.js");
        context.Files.Add("/themes/shop/js/photoswipe-ui.min.js");
        context.Files.Add("/themes/shop/js/simple-scrollbar.min.js");
        context.Files.Add("/themes/shop/js/headroom.min.js");
        context.Files.Add("/themes/shop/js/rellax.min.js");
        context.Files.Add("/themes/shop/js/jquery.zoom.min.js");
        context.Files.Add("/themes/shop/js/notify.min.js");
        context.Files.Add("/themes/shop/js/background-color-theif.js");
    }
}
