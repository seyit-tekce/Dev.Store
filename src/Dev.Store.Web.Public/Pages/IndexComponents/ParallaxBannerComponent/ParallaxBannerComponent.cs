using Dev.Store.HomeSliders;
using Dev.Store.Web.Public.Pages.IndexComponents.HomeSliderComponent;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Dev.Store.Web.Public.Pages.IndexComponents.ParallaxBannerComponent
{
    public class ParallaxBannerComponent :  AbpViewComponent
    {
        private readonly IHomeSliderAppService _homeSliderAppService;
        public HomeSliderModel Model { get; set; } = new HomeSliderModel();
        public ParallaxBannerComponent(IHomeSliderAppService homeSliderAppService)
        {
            this._homeSliderAppService = homeSliderAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Model.Sliders = await _homeSliderAppService.GetListByType(HomeSliderType.ParallaxBanner);
            return View("~/Pages/IndexComponents/ParallaxBannerComponent/Default.cshtml", Model);
        }
    }
}
