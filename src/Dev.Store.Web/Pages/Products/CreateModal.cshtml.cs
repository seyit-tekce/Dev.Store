using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dev.Store.Products;
using Dev.Store.Products.Dtos;
using Dev.Store.Web.Pages.Products.Product.ViewModels;

namespace Dev.Store.Web.Pages.Products.Product;

public class CreateModalModel : StorePageModel
{
    [BindProperty]
    public CreateEditProductViewModel ViewModel { get; set; }

    private readonly IProductAppService _service;

    public CreateModalModel(IProductAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditProductViewModel, CreateUpdateProductDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}