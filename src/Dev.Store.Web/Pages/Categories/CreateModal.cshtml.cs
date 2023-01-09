using Dev.Store.Categories;
using Dev.Store.Categories.Dtos;
using Dev.Store.Web.Pages.Entities.Category.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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