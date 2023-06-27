using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.Address;

public class AddressRepository : EfCoreRepository<StoreDbContext, Address, Guid>, IAddressRepository
{
    public AddressRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Address>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}