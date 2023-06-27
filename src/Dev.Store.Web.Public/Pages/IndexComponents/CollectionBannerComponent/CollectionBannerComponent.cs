using Dev.Store.HomeSliders;
using Dev.Store.Web.Public.Pages.IndexComponents.HomeSliderComponent;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Dev.Store.Web.Public.Pages.IndexComponents.CollectionBannerComponent
{
    public class CollectionBannerComponent : AbpViewComponent
    {
        private readonly IHomeSliderAppService _homeSliderAppService;
        public HomeSliderModel Model { get; set; } = new HomeSliderModel();
        public CollectionBannerComponent(IHomeSliderAppService homeSliderAppService)
        {
            this._homeSliderAppService = homeSliderAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Model.Sliders = await _homeSliderAppService.GetListByType(HomeSliderType.CollectionBanner);

            return View("~/Pages/IndexComponents/CollectionBannerComponent/Default.cshtml", Model);
        }
    }
}
