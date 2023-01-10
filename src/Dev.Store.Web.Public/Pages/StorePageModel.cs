using Dev.Store.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Dev.Store.Web.Public.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class StorePageModel : AbpPageModel
{
    protected StorePageModel()
    {
        LocalizationResourceType = typeof(StoreResource);
    }
}
