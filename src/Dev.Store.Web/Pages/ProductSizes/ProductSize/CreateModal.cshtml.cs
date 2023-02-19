using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dev.Store.ProductSizes;
using Dev.Store.ProductSizes.Dtos;
using Dev.Store.Web.Pages.ProductSizes.ProductSize.ViewModels;

namespace Dev.Store.Web.Pages.ProductSizes.ProductSize;

public class CreateModalModel : StorePageModel
{
    [BindProperty]
    public CreateEditProductSizeViewModel ViewModel { get; set; }

    private readonly IProductSizeAppService _service;

    public CreateModalModel(IProductSizeAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditProductSizeViewModel, CreateUpdateProductSizeDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}