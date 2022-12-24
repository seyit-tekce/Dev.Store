using Dev.Store.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Dev.Store.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class StoreController : AbpControllerBase
{
    protected StoreController()
    {
        LocalizationResource = typeof(StoreResource);
    }
}
