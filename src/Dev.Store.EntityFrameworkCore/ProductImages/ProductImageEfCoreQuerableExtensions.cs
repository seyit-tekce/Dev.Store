using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dev.Store.ProductImages;

public static class ProductImageEfCoreQueryableExtensions
{
    public static IQueryable<ProductImage> IncludeDetails(this IQueryable<ProductImage> queryable, bool include = true)
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
