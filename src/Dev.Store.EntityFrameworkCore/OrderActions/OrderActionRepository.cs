using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.OrderActions;

public class OrderActionRepository : EfCoreRepository<StoreDbContext, OrderAction, Guid>, IOrderActionRepository
{
    public OrderActionRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<OrderAction>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}