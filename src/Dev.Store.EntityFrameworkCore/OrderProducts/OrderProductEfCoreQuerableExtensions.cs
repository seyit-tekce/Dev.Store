using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dev.Store.OrderProducts;

/// <summary>
/// 
/// </summary>
public static class OrderProductEfCoreQueryableExtensions
{
    public static IQueryable<OrderProduct> IncludeDetails(this IQueryable<OrderProduct> queryable, bool include = true)
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
