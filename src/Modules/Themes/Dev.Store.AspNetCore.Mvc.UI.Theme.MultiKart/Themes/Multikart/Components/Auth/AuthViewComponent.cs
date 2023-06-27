using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart.Themes.MultiKart.Components.Auth;

[Widget(RefreshUrl = "Widgets/Theme/Auth", ScriptFiles =new string[] { "/Themes/Multikart/Components/Auth/default.js" })]
public class AuthViewComponent : AbpViewComponent
{
    public virtual IViewComponentResult Invoke()
    {
        return View("~/Themes/Multikart/Components/Auth/Default.cshtml");
    }
}
