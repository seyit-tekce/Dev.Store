using Dev.Store.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.SeoSettings;

public class SeoSettingRepository : EfCoreRepository<StoreDbContext, SeoSetting, Guid>, ISeoSettingRepository
{
    public SeoSettingRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<SeoSetting>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}