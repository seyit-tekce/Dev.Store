using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.Dev.Store.Brand;

public class IndexModel : StorePageModel
{
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

