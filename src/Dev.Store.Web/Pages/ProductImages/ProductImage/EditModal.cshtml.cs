using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dev.Store.ProductImages;
using Dev.Store.ProductImages.Dtos;
using Dev.Store.Web.Pages.ProductImages.ProductImage.ViewModels;

namespace Dev.Store.Web.Pages.ProductImages.ProductImage;

public class EditModalModel : StorePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditProductImageViewModel ViewModel { get; set; }

    private readonly IProductImageAppService _service;

    public EditModalModel(IProductImageAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<ProductImageDto, CreateEditProductImageViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditProductImageViewModel, CreateUpdateProductImageDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}