using Dev.Store.Categories;
using Dev.Store.Categories.Dtos;
using Dev.Store.Web.Pages.Entities.Category.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.Entities.Category;

public class EditModalModel : StorePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditCategoryViewModel ViewModel { get; set; }

    private readonly ICategoryAppService _service;

    public EditModalModel(ICategoryAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<CategoryDto, CreateEditCategoryViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditCategoryViewModel, CreateUpdateCategoryDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}