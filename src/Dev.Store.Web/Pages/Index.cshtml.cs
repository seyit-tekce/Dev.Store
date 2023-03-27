using Microsoft.AspNetCore.Authorization;

namespace Dev.Store.Web.Pages;
[Authorize]
public class IndexModel : StorePageModel
{

    public void OnGet()
    {

    }
}
