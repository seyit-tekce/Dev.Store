using System;
using System.Collections.Generic;
using System.Text;
using Dev.Store.Localization;
using Volo.Abp.Application.Services;

namespace Dev.Store;

/* Inherit your application services from this class.
 */
public abstract class StoreAppService : ApplicationService
{
    protected StoreAppService()
    {
        LocalizationResource = typeof(StoreResource);
    }
}
