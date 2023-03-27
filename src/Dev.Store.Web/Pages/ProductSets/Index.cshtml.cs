using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.ProductSets.ProductSet;

public class IndexModel : StorePageModel
{

    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}
