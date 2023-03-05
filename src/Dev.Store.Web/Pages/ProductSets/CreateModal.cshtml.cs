using Dev.Store.ProductSets;
using Dev.Store.ProductSets.Dtos;
using Dev.Store.Web.Pages.ProductSets.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.ProductSets;

public class CreateModalModel : StorePageModel
{
    [BindProperty]
    public CreateEditProductSetViewModel ViewModel { get; set; }

    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid ProductId { get; set; }

    private readonly IProductSetAppService _service;

    public CreateModalModel(IProductSetAppService service)
    {
        _service = service;
    }

    public async Task OnGetAsync()
    {
        this.ViewModel = new CreateEditProductSetViewModel()
        {
            ProductId = this.ProductId
        };
        await Task.CompletedTask;

    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditProductSetViewModel, CreateUpdateProductSetDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}