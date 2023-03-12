using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Bundling;

public class BasicThemeGlobalStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.RemoveAll(x => 1 == 1);
        context.Files.Add("/themes/shop/css/bootstrap.css");
        context.Files.Add("/themes/shop/css/editor-blocks.css");
        context.Files.Add("/themes/shop/css/font-awesome.min.css");
        context.Files.Add("/themes/shop/css/photoswipe.css");
        context.Files.Add("/themes/shop/css/photoswipe-ui.css");
        context.Files.Add("/themes/shop/css/style-editor.css");
    }
}
