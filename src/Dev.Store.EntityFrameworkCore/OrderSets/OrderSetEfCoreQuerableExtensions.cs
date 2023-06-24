using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dev.Store.OrderSets;

/// <summary>
/// 
/// </summary>
public static class OrderSetEfCoreQueryableExtensions
{
    public static IQueryable<OrderSet> IncludeDetails(this IQueryable<OrderSet> queryable, bool include = true)
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
