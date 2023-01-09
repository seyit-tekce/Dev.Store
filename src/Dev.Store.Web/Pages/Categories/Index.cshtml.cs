using Dev.Store.Categories;
using Dev.Store.Categories.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.Entities.Category;

public class IndexModel : StorePageModel
{
    [BindProperty(SupportsGet = true)]
    public Guid? Id { get; set; }

    private readonly ICategoryAppService categoryAppService;
    public CategoryDto Category { get; set; }
    public IndexModel(ICategoryAppService categoryAppService)
    {
        this.categoryAppService = categoryAppService;
    }

    public virtual async Task OnGetAsync()
    {
        if (this.Id.HasValue)
        {
            this.Category = await categoryAppService.GetAsync(this.Id.Value);
        }
        await Task.CompletedTask;
    }
}

