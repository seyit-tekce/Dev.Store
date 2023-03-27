using Dev.Store.ProductSizes;
using Dev.Store.ProductSizes.Dtos;
using Dev.Store.Web.Pages.ProductSizes.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.ProductSizes;

public class CreateModalModel : StorePageModel
{
    [BindProperty]
    public CreateEditProductSizeViewModel ViewModel { get; set; }

    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid ProductId { get; set; }

    private readonly IProductSizeAppService _service;

    public CreateModalModel(IProductSizeAppService service)
    {
        _service = service;
    }
    public async Task OnGetAsync()
    {
        this.ViewModel = new CreateEditProductSizeViewModel()
        {
            ProductId = this.ProductId
        };
        await Task.CompletedTask;

    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditProductSizeViewModel, CreateUpdateProductSizeDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}