using System.Linq;

namespace Dev.Store.ProductSizes;

public static class ProductSizeEfCoreQueryableExtensions
{
    public static IQueryable<ProductSize> IncludeDetails(this IQueryable<ProductSize> queryable, bool include = true)
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
