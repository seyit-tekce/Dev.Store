using Dev.Store.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.Locations;

public class LocationRepository : EfCoreRepository<StoreDbContext, Location, Guid>, ILocationRepository
{
    public LocationRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Location>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}