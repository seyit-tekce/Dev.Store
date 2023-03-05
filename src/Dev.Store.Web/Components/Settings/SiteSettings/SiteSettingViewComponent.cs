using Dev.Store.Settings;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Dev.Store.Web.Components.Settings.SiteSettings
{
    //[Widget(ScriptFiles = new[] { "/Components/Settings/SiteSettings/defult.js" })]
    public class SiteSettingViewComponent : AbpViewComponent
    {
        private readonly ISiteSettingAppService siteSettingSettingAppService;

        public SiteSettingViewComponent(ISiteSettingAppService siteSettingSettingAppService)
        {
            this.siteSettingSettingAppService = siteSettingSettingAppService;
        }

        public virtual async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Components/Settings/SiteSettings/Default.cshtml", await siteSettingSettingAppService.GetAsync());
        }
    }
}