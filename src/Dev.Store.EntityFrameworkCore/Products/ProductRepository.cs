using Dev.Store.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        return await queryable.Include(x => x.Category).Include(x => x.Brand).Include(x => x.ProductImages).ThenInclude(x => x.UploadFile).Where(x => x.CategoryId == categoryId).OrderBy(x => x.CreationTime).Skip(skip).Take(take).ToListAsync();
    }

    public async Task<Product> GetProductWithDetailsByCategoryAndCode(Guid categoryId, string code)
    {
        var queryable = await GetQueryableAsync();
        var details = queryable
            .Include(x => x.Category)
            .Include(x => x.Brand)
            .Include(x => x.ProductImages).ThenInclude(x => x.UploadFile)
            .Include(x => x.ProductSets)
            .Include(x => x.ProductImages)
            .Include(x => x.ProductSizes);
        return await details.Where(a => a.CategoryId == categoryId && a.Code == code).FirstOrDefaultAsync();
    }

    public override async Task<IQueryable<Product>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}