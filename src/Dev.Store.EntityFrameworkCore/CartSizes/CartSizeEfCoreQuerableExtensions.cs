using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dev.Store.CartSizes;

/// <summary>
/// 
/// </summary>
public static class CartSizeEfCoreQueryableExtensions
{
    public static IQueryable<CartSize> IncludeDetails(this IQueryable<CartSize> queryable, bool include = true)
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
