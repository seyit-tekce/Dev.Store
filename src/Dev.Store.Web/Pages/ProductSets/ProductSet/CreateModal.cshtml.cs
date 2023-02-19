using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dev.Store.ProductSets;
using Dev.Store.ProductSets.Dtos;
using Dev.Store.Web.Pages.ProductSets.ProductSet.ViewModels;

namespace Dev.Store.Web.Pages.ProductSets.ProductSet;

public class CreateModalModel : StorePageModel
{
    [BindProperty]
    public CreateEditProductSetViewModel ViewModel { get; set; }

    private readonly IProductSetAppService _service;

    public CreateModalModel(IProductSetAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditProductSetViewModel, CreateUpdateProductSetDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}