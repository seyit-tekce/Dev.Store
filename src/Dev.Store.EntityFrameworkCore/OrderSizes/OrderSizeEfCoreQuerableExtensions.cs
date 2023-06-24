using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dev.Store.OrderSizes;

/// <summary>
/// 
/// </summary>
public static class OrderSizeEfCoreQueryableExtensions
{
    public static IQueryable<OrderSize> IncludeDetails(this IQueryable<OrderSize> queryable, bool include = true)
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
