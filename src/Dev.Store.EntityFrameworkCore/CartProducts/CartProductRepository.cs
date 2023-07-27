using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.EntityFrameworkCore;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.CartProducts;

public class CartProductRepository : EfCoreRepository<StoreDbContext, CartProduct, Guid>, ICartProductRepository
{
    public CartProductRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<IEnumerable<CartProduct>> GetUserCartAsync(Guid? userId = null, Guid? sessionId = null)
    {
        return await (await GetQueryableAsync())
            .Include(x => x.CartSets).ThenInclude(x => x.ProductSet)
            .Include(x => x.CartSizes).ThenInclude(x => x.ProductSize)
            .Include(x => x.Product)
            .ThenInclude(x => x.ProductImages)
            .Where(x => x.SessionId == sessionId || (x.CreatorId == userId && x.CreatorId != null)).ToListAsync();
    }

    public override async Task<IQueryable<CartProduct>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}