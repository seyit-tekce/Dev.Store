using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.Entities.Category;

public class IndexModel : StorePageModel
{
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

