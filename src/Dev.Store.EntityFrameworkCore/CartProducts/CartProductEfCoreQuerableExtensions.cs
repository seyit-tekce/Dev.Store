using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dev.Store.CartProducts;

/// <summary>
/// 
/// </summary>
public static class CartProductEfCoreQueryableExtensions
{
    public static IQueryable<CartProduct> IncludeDetails(this IQueryable<CartProduct> queryable, bool include = true)
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
