using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Dev.Store.Web.Public.Pages.IndexComponents.HomeSliderComponent
{
    public class HomeSliderComponent :  AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Pages/IndexComponents/HomeSliderComponent/Default.cshtml");
        }
    }
}
