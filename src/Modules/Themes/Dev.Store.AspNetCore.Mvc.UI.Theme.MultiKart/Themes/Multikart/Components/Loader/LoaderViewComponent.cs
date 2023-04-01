using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart.Themes.MultiKart.Components.Loader
{
    public class LoaderViewComponent : AbpViewComponent
    {
        public virtual IViewComponentResult Invoke()
        {
            return View("~/Themes/Multikart/Components/Loader/Default.cshtml");
        }
    }
}
