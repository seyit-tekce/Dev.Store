using Dev.Store.Settings;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Dev.Store.Web.Components.Settings.SiteSettings
{
    public class HomeSliderSettingViewComponent : AbpViewComponent
    {
        private readonly IHomeSliderAppService _homeSliderAppService;

        public HomeSliderSettingViewComponent(IHomeSliderAppService homeSliderAppService)
        {
            _homeSliderAppService = homeSliderAppService;
        }

        public virtual async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Components/Settings/HomeSliderSetting/Default.cshtml", await _homeSliderAppService.GetAsync());
        }
    }
}