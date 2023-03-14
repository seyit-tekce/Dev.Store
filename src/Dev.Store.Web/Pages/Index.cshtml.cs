using Microsoft.AspNetCore.Authorization;

namespace Dev.Store.Web.Pages;

public class IndexModel : StorePageModel
{
    [Authorize]
    public void OnGet()
    {

    }
}
