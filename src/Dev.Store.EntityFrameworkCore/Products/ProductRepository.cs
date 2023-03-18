using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.Products;

public class ProductRepository : EfCoreRepository<StoreDbContext, Product, Guid>, IProductRepository
{
    public ProductRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<int> GetCountByCategoryId(Guid categoryId)
    {
        return await (await GetQueryableAsync()).CountAsync(x => x.CategoryId == categoryId);
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryId(Guid categoryId, int skip = 0, int take = 50)
    {
        var queryable = await GetQueryableAsync();
        queryable.Include(x => x.Category);
        queryable.Include(x => x.Brand);
        queryable.Include(x => x.ProductImages);
        queryable.Include(x => x.ProductSets);
        queryable.Include(x => x.ProductSizes);
        return await queryable.Where(x => x.CategoryId == categoryId).OrderBy(x => x.CreationTime).Skip(skip).Take(take).ToListAsync();
    }

    public override async Task<IQueryable<Product>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}