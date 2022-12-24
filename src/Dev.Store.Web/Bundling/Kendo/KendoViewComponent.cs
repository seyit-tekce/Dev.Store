using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Dev.StoreAbp.Web.Bundling.Kendo
{
    public class KendoViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("/Components/Kendo/Default.cshtml");
        }
    }
}
