using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dev.Store.HomeSliders;
using Dev.Store.HomeSliders.Dtos;
using Dev.Store.Web.Pages.HomeSliders.HomeSlider.ViewModels;

namespace Dev.Store.Web.Pages.HomeSliders.HomeSlider;

public class EditModalModel : StorePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditHomeSliderViewModel ViewModel { get; set; }

    private readonly IHomeSliderAppService _service;

    public EditModalModel(IHomeSliderAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<HomeSliderDto, CreateEditHomeSliderViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditHomeSliderViewModel, CreateUpdateHomeSliderDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}