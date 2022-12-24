using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dev.Store;
using Dev.Store.Dtos;
using Dev.Store.Web.Pages.Dev.Store.Brand.ViewModels;

namespace Dev.Store.Web.Pages.Dev.Store.Brand;

public class EditModalModel : StorePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditBrandViewModel ViewModel { get; set; }

    private readonly IBrandAppService _service;

    public EditModalModel(IBrandAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<BrandDto, CreateEditBrandViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditBrandViewModel, CreateUpdateBrandDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}