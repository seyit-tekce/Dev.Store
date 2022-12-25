using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dev.Store.Entities;

public static class BrandEfCoreQueryableExtensions
{
    public static IQueryable<Brand> IncludeDetails(this IQueryable<Brand> queryable, bool include = true)
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
