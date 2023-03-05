using Dev.Store.ProductSets;
using Dev.Store.ProductSets.Dtos;
using Dev.Store.Web.Pages.ProductSets.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.ProductSets;

public class EditModalModel : StorePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditProductSetViewModel ViewModel { get; set; }

    private readonly IProductSetAppService _service;

    public EditModalModel(IProductSetAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<ProductSetDto, CreateEditProductSetViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditProductSetViewModel, CreateUpdateProductSetDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}