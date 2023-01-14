using System.Linq;

namespace Dev.Store.Keywords;

public static class KeywordEfCoreQueryableExtensions
{
    public static IQueryable<Keyword> IncludeDetails(this IQueryable<Keyword> queryable, bool include = true)
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
