using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dev.Store.ProductSizes;
using Dev.Store.ProductSizes.Dtos;
using Dev.Store.Web.Pages.ProductSizes.ProductSize.ViewModels;

namespace Dev.Store.Web.Pages.ProductSizes.ProductSize;

public class EditModalModel : StorePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditProductSizeViewModel ViewModel { get; set; }

    private readonly IProductSizeAppService _service;

    public EditModalModel(IProductSizeAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<ProductSizeDto, CreateEditProductSizeViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditProductSizeViewModel, CreateUpdateProductSizeDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}