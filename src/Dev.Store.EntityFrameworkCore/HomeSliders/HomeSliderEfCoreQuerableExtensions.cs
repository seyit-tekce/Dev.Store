using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dev.Store.HomeSliders;

public static class HomeSliderEfCoreQueryableExtensions
{
    public static IQueryable<HomeSlider> IncludeDetails(this IQueryable<HomeSlider> queryable, bool include = true)
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
