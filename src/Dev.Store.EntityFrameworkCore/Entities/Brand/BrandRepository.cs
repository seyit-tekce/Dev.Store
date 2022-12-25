using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.EntityFrameworkCore;
using Dev.Store.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.Entities;

public class BrandRepository : EfCoreRepository<StoreDbContext, Brand, Guid>, IBrandRepository
{
    public BrandRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Brand>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}