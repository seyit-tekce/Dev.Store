using Dev.Store.HomeSliders;
using Dev.Store.HomeSliders.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
namespace Dev.Store.Web.Public.Pages.IndexComponents.HomeSliderComponent
{
    public class HomeSliderComponent : AbpViewComponent
    {
        private readonly IHomeSliderAppService _homeSliderAppService;
        public HomeSliderModel Model { get; set; } = new HomeSliderModel();
        public HomeSliderComponent(IHomeSliderAppService homeSliderAppService)
        {
            _homeSliderAppService = homeSliderAppService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Model.Sliders = await _homeSliderAppService.GetListByType(HomeSliderType.HomeSlider);
            return View("~/Pages/IndexComponents/HomeSliderComponent/Default.cshtml", Model);
        }
    }
    public class HomeSliderModel
    {
        public IEnumerable<HomeSliderDto> Sliders { get; set; }
    }
}
