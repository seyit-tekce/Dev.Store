using Dev.Store.Entities;
using Dev.Store.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.Entities.Category;

public class IndexModel : StorePageModel
{
    [BindProperty]
    public Guid? Id { get; set; }

    private readonly ICategoryAppService categoryAppService;
    public CategoryDto Category { get; set; }
    public IndexModel(ICategoryAppService categoryAppService)
    {
        this.categoryAppService = categoryAppService;
    }
    
    public virtual async Task OnGetAsync(Guid? id)
    {
        this.Id = id;
        if (this.Id.HasValue)
        {
            this.Category= await categoryAppService.GetAsync(this.Id.Value);
        }
        await Task.CompletedTask;
    }
}

