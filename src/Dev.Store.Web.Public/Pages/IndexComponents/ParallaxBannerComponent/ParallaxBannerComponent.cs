using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Dev.Store.Web.Public.Pages.IndexComponents.ParallaxBannerComponent
{
    public class ParallaxBannerComponent :  AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Pages/IndexComponents/ParallaxBannerComponent/Default.cshtml");
        }
    }
}
