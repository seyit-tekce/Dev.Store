using Dev.Store.Locations;
using Dev.Store.Locations.Dtos;
using Dev.Store.Web.Pages.Entities.Category.ViewModels;
using Dev.Store.Web.Pages.Locations.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.Locations;

public class CreateModalModel : StorePageModel
{
    [BindProperty]
    public CreateEditLocationViewModel ViewModel { get; set; }

    private readonly ILocationAppService _service;

    public CreateModalModel(ILocationAppService service)
    {
        _service = service;
    }
    public virtual async Task OnGetAsync(Guid? locationParentId)
    {
        this.ViewModel = new CreateEditLocationViewModel();
        this.ViewModel.LocationParentId = locationParentId;
        await Task.CompletedTask;

    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditLocationViewModel, CreateUpdateLocationDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}