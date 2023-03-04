using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.ProductImages;

public class ProductImageRepository : EfCoreRepository<StoreDbContext, ProductImage, Guid>, IProductImageRepository
{
    public ProductImageRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<ProductImage>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}