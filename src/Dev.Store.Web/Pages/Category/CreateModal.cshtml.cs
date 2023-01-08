using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dev.Store.Entities;
using Dev.Store.Entities.Dtos;
using Dev.Store.Web.Pages.Entities.Category.ViewModels;
using System;

namespace Dev.Store.Web.Pages.Entities.Category;

public class CreateModalModel : StorePageModel
{
    [BindProperty]
    public CreateEditCategoryViewModel ViewModel { get; set; }

    private readonly ICategoryAppService _service;

    public CreateModalModel(ICategoryAppService service)
    {
        _service = service;
    }
    public virtual async Task OnGetAsync(Guid? categoryParentId)
    {
        this.ViewModel = new CreateEditCategoryViewModel();
        this.ViewModel.CategoryParentId = categoryParentId;
        await Task.CompletedTask;

    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditCategoryViewModel, CreateUpdateCategoryDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}