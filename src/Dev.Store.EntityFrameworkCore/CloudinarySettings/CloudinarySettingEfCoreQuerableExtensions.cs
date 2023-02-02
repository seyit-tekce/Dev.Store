using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dev.Store.CloudinarySettings;

public static class CloudinarySettingEfCoreQueryableExtensions
{
    public static IQueryable<CloudinarySetting> IncludeDetails(this IQueryable<CloudinarySetting> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
            // .Include(x => x.xxx) // TODO: AbpHelper generated
            ;
    }
}
