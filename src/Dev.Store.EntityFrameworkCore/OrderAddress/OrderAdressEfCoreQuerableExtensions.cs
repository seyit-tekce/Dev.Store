using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dev.Store.OrderAddress;

/// <summary>
/// 
/// </summary>
public static class OrderAdressEfCoreQueryableExtensions
{
    public static IQueryable<OrderAdress> IncludeDetails(this IQueryable<OrderAdress> queryable, bool include = true)
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
