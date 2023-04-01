using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart.Themes.MultiKart.Components.Brand;

public class MainNavbarBrandViewComponent : AbpViewComponent
{
    public virtual IViewComponentResult Invoke()
    {
        return View("~/Themes/Multikart/Components/Brand/Default.cshtml");
    }
}
