using Dev.Store.Categories;
using Dev.Store.Categories.Dtos;
using Dev.Store.Products;
using Dev.Store.Products.Dtos;
using Dev.Store.Web.Pages.Products.Product.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.Products.Product;

public class CreateModalModel : StorePageModel
{
    [BindProperty]
    public CreateEditProductViewModel ViewModel { get; set; }

    private readonly IProductAppService _service;
    private readonly ICategoryAppService _categoryAppService;
    public IEnumerable<CategoryDto> Categories { get; set; }

    public CreateModalModel(IProductAppService service, ICategoryAppService categoryAppService)
    {
        _service = service;
        _categoryAppService = categoryAppService;
    }

    public virtual async Task OnGetAsync()
    {
        Categories = await _categoryAppService.GetCategoriesAsync();
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditProductViewModel, CreateUpdateProductDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}