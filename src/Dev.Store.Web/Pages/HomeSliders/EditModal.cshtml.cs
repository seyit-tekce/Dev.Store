using Dev.Store.HomeSliders;
using Dev.Store.HomeSliders.Dtos;
using Dev.Store.Web.Pages.HomeSliders.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.HomeSliders
{
    public class EditModalModel : StorePageModel
    {
        [BindProperty]
        public CreateEditHomeSliderViewModel ViewModel { get; set; }

        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        private readonly IHomeSliderAppService homeSliderAppService;

        public EditModalModel(IHomeSliderAppService homeSliderAppService)
        {
            this.homeSliderAppService = homeSliderAppService;
        }
        public async Task OnGetAsync()
        {
            var homeSlider = await homeSliderAppService.GetAsync(Id);
            ViewModel = ObjectMapper.Map<HomeSliderDto, CreateEditHomeSliderViewModel>(homeSlider);
            await Task.CompletedTask;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditHomeSliderViewModel, CreateUpdateHomeSliderDto>(ViewModel);
            await homeSliderAppService.UpdateAsync(Id,dto);
            return NoContent();
        }
    }
}
