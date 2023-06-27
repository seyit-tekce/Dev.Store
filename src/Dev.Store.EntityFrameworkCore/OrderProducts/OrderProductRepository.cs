using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.OrderProducts;

public class OrderProductRepository : EfCoreRepository<StoreDbContext, OrderProduct, Guid>, IOrderProductRepository
{
    public OrderProductRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<OrderProduct>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}