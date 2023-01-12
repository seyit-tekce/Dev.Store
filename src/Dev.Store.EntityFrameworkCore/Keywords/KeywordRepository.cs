using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.Keywords;

public class KeywordRepository : EfCoreRepository<StoreDbContext, Keyword, Guid>, IKeywordRepository
{
    public KeywordRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Keyword>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}