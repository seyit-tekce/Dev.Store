using Dev.Store.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.ProductSizes;

public class ProductSizeRepository : EfCoreRepository<StoreDbContext, ProductSize, Guid>, IProductSizeRepository
{
    public ProductSizeRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<IEnumerable<ProductSize>> GetAllByProductIdAsync(IEnumerable<Guid> productIds)
    {
        var queryable = await GetQueryableAsync();
        return queryable.Where(x => productIds.Any(a => a == x.ProductId));
    }

    public override async Task<IQueryable<ProductSize>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}