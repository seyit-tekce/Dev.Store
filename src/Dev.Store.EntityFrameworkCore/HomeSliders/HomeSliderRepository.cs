using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Dev.Store.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.HomeSliders;

public class HomeSliderRepository : EfCoreRepository<StoreDbContext, HomeSlider, Guid>, IHomeSliderRepository
{
    public HomeSliderRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<HomeSlider> GetByIdAsync(Guid id)
    {
        return await (await GetQueryableAsync()).Include(x => x.UploadFile).Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public override async Task<IQueryable<HomeSlider>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
    public async Task<IQueryable<HomeSlider>> WithDetailsAsync(HomeSliderType type)
    {
        return (await GetQueryableAsync()).Include(x => x.UploadFile).Where(x => x.Type == type);
    }
}