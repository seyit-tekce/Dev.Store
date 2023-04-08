using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Dev.Store.Web.Public.Pages.IndexComponents.CollectionBannerComponent
{
    public class CollectionBannerComponent :  AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Pages/IndexComponents/CollectionBannerComponent/Default.cshtml");
        }
    }
}
