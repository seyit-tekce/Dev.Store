using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dev.Store.HomeSliders;
using Dev.Store.HomeSliders.Dtos;
using Dev.Store.Web.Pages.HomeSliders.HomeSlider.ViewModels;

namespace Dev.Store.Web.Pages.HomeSliders.HomeSlider;

public class CreateModalModel : StorePageModel
{
    [BindProperty]
    public CreateEditHomeSliderViewModel ViewModel { get; set; }

    private readonly IHomeSliderAppService _service;

    public CreateModalModel(IHomeSliderAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditHomeSliderViewModel, CreateUpdateHomeSliderDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}