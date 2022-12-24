using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dev.Store;
using Dev.Store.Dtos;
using Dev.Store.Web.Pages.Dev.Store.Brand.ViewModels;

namespace Dev.Store.Web.Pages.Dev.Store.Brand;

public class CreateModalModel : StorePageModel
{
    [BindProperty]
    public CreateEditBrandViewModel ViewModel { get; set; }

    private readonly IBrandAppService _service;

    public CreateModalModel(IBrandAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditBrandViewModel, CreateUpdateBrandDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}