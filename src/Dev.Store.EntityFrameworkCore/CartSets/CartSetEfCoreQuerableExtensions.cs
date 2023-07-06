using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dev.Store.CartSets;

/// <summary>
/// 
/// </summary>
public static class CartSetEfCoreQueryableExtensions
{
    public static IQueryable<CartSet> IncludeDetails(this IQueryable<CartSet> queryable, bool include = true)
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
