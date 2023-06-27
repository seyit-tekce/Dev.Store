using Dev.Store.HomeSliders;
using Dev.Store.HomeSliders.Dtos;
using Dev.Store.Web.Pages.HomeSliders.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.HomeSliders
{
    public class CreateModalModel : StorePageModel
    {
        [BindProperty]
        public CreateEditHomeSliderViewModel ViewModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public HomeSliderType Type { get; set; }
        private readonly IHomeSliderAppService homeSliderAppService;

        public CreateModalModel(IHomeSliderAppService homeSliderAppService)
        {
            this.homeSliderAppService = homeSliderAppService;
        }

        public async Task OnGetAsync()
        {
            ViewModel = new CreateEditHomeSliderViewModel { Type = this.Type };
            await Task.CompletedTask;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditHomeSliderViewModel, CreateUpdateHomeSliderDto>(ViewModel);
            await homeSliderAppService.CreateAsync(dto);
            return NoContent();
        }
    }
}
