using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.Keywords;

public class IndexModel : StorePageModel
{

    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}


