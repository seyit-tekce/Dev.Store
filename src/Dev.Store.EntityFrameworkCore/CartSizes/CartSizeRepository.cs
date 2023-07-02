using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.CartSizes;

public class CartSizeRepository : EfCoreRepository<StoreDbContext, CartSize, Guid>, ICartSizeRepository
{
    public CartSizeRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<CartSize>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}