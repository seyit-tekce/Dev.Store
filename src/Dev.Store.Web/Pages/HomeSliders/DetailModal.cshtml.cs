using Dev.Store.HomeSliders;
using Dev.Store.HomeSliders.Dtos;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.HomeSliders
{
    public class DetailModalModel : PageModel
    {
        private readonly IHomeSliderAppService _homeSliderAppService;

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public HomeSliderDto HomeSlider { get; set; }
        public DetailModalModel(IHomeSliderAppService homeSliderAppService)
        {
            _homeSliderAppService = homeSliderAppService;
        }

        public async Task OnGetAsync()
        {
            HomeSlider = await _homeSliderAppService.GetAsync(Id);



        }
    }
}
