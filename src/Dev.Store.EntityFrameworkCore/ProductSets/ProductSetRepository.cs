using Dev.Store.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.ProductSets;

public class ProductSetRepository : EfCoreRepository<StoreDbContext, ProductSet, Guid>, IProductSetRepository
{
    public ProductSetRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<ProductSet>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}