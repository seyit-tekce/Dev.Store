using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dev.Store.ProductImages;
using Dev.Store.ProductImages.Dtos;
using Dev.Store.Web.Pages.ProductImages.ProductImage.ViewModels;

namespace Dev.Store.Web.Pages.ProductImages.ProductImage;

public class CreateModalModel : StorePageModel
{
    [BindProperty]
    public CreateEditProductImageViewModel ViewModel { get; set; }

    private readonly IProductImageAppService _service;

    public CreateModalModel(IProductImageAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditProductImageViewModel, CreateUpdateProductImageDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}