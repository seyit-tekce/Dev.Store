using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.Products.Product;

public class IndexModel : StorePageModel
{

    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}
