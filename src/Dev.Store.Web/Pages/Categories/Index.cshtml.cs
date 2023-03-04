using Dev.Store.Categories;
using Dev.Store.Categories.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Layout;

namespace Dev.Store.Web.Pages.Entities.Category;

public class IndexModel : StorePageModel
{
    [BindProperty(SupportsGet = true)]
    public Guid? Id { get; set; }

    private readonly ICategoryAppService categoryAppService;
    public CategoryDto Category { get; set; }
    public BreadCrumb BreadCrumb { get; set; } = new BreadCrumb();
    public IndexModel(ICategoryAppService categoryAppService)
    {
        this.categoryAppService = categoryAppService;
    }

    public virtual async Task OnGetAsync()
    { 
        this.BreadCrumb.Add(L["Menu:Category"].Value, "/Categories");
        if (this.Id.HasValue)
        {
            this.Category = await categoryAppService.GetAsync(this.Id.Value);
           
            if (this.Category.CategoryParentId.HasValue)
            {
                await GetBreadCrumbAsync(this.Category.CategoryParentId.Value);

            }
        }


        await Task.CompletedTask;
    }

    private async Task GetBreadCrumbAsync(Guid categoryId)
    {
        var category = await categoryAppService.GetAsync(categoryId);
        if (category != null)
        {
            BreadCrumb.Add(category.Name, "/Categories/" + category.Id);
            if (category.CategoryParentId.HasValue)
            {
                await GetBreadCrumbAsync(category.CategoryParentId.Value);
            }

        }
    }
}

