using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.HomeSliders;

public class HomeSliderRepository : EfCoreRepository<StoreDbContext, HomeSlider, Guid>, IHomeSliderRepository
{
    public HomeSliderRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<HomeSlider>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}