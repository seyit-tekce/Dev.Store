using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.ProductSizes;

public class ProductSizeRepository : EfCoreRepository<StoreDbContext, ProductSize, Guid>, IProductSizeRepository
{
    public ProductSizeRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<ProductSize>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}