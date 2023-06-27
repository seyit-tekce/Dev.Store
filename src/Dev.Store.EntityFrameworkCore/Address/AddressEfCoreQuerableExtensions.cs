using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dev.Store.Address;

/// <summary>
/// 
/// </summary>
public static class AddressEfCoreQueryableExtensions
{
    public static IQueryable<Address> IncludeDetails(this IQueryable<Address> queryable, bool include = true)
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
