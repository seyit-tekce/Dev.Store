using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.OrderSets;

public class OrderSetRepository : EfCoreRepository<StoreDbContext, OrderSet, Guid>, IOrderSetRepository
{
    public OrderSetRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<OrderSet>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}