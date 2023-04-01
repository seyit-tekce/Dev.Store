using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart.Themes.Multikart.Components.Footer
{
    public class FooterViewComponent : AbpViewComponent
    {
        public virtual IViewComponentResult Invoke()
        {
            return View("~/Themes/Multikart/Components/Footer/Default.cshtml");
        }
    }
}