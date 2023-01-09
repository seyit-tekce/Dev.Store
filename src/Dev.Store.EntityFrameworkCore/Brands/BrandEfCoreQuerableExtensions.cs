using System.Linq;

namespace Dev.Store.Brands;

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
