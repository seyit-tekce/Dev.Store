using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart.Controller
{
    [Route("Widgets")]
    public class WidgetsController : AbpController
    {
        [HttpGet]
        [Route("Theme/Auth")]
        public IActionResult MainNavbar()
        {
            return ViewComponent("Auth");
        }

    }
}
