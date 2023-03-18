using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.ProductImages;

public class ProductImageRepository : EfCoreRepository<StoreDbContext, ProductImage, Guid>, IProductImageRepository
{
    public ProductImageRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<IEnumerable<ProductImage>> GetAllMainByProductIdAsync(IEnumerable<Guid> productIds)
    {
        var queryable = await GetQueryableAsync();
        queryable.Include(x => x.UploadFile);
        return queryable.Where(x => x.IsMain && productIds.Any(a => a == x.ProductId));
    }

    public override async Task<IQueryable<ProductImage>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}