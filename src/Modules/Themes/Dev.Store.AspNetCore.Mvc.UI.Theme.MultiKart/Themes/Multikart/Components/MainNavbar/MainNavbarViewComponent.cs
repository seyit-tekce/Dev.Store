using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart.Themes.MultiKart.Components.MainNavbar;

public class MainNavbarViewComponent : AbpViewComponent
{
    public virtual IViewComponentResult Invoke()
    {
        return View("~/Themes/Multikart/Components/MainNavbar/Default.cshtml");
    }
}
