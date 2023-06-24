using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dev.Store.OrderActions;

/// <summary>
/// 
/// </summary>
public static class OrderActionEfCoreQueryableExtensions
{
    public static IQueryable<OrderAction> IncludeDetails(this IQueryable<OrderAction> queryable, bool include = true)
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
