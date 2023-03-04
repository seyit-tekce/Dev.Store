using Dev.Store.Categories;
using Dev.Store.Categories.Dtos;
using Dev.Store.Products;
using Dev.Store.Products.Dtos;
using Dev.Store.Web.Pages.Products.Product.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.Products.Product;

public class EditModalModel : StorePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditProductViewModel ViewModel { get; set; }
    private readonly ICategoryAppService _categoryAppService;
    public List<CategoryDto> Categories { get; set; }

    private readonly IProductAppService _service;

    public EditModalModel(IProductAppService service, ICategoryAppService categoryAppService)
    {
        _service = service;
        _categoryAppService = categoryAppService;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<ProductDto, CreateEditProductViewModel>(dto);
        Categories = (await _categoryAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto())).Items.ToList();

    }
    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditProductViewModel, CreateUpdateProductDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}