using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.OrderSizes;

public class OrderSizeRepository : EfCoreRepository<StoreDbContext, OrderSize, Guid>, IOrderSizeRepository
{
    public OrderSizeRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<OrderSize>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}