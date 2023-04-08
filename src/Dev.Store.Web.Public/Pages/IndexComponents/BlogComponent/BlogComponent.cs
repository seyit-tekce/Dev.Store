using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Dev.Store.Web.Public.Pages.IndexComponents.BlogComponent
{
    public class BlogComponent :  AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Pages/IndexComponents/BlogComponent/Default.cshtml");
        }
    }
}
