using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dev.Store.SeoSettings;

public static class SeoSettingEfCoreQueryableExtensions
{
    public static IQueryable<SeoSetting> IncludeDetails(this IQueryable<SeoSetting> queryable, bool include = true)
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
