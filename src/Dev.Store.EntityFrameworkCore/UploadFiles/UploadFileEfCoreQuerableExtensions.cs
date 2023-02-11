using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dev.Store.UploadFiles;

public static class UploadFileEfCoreQueryableExtensions
{
    public static IQueryable<UploadFile> IncludeDetails(this IQueryable<UploadFile> queryable, bool include = true)
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
