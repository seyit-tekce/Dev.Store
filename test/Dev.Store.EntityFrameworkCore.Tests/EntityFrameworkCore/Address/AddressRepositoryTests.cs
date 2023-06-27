using System;
using System.Threading.Tasks;
using Dev.Store.Address;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Dev.Store.EntityFrameworkCore.Address;

public class AddressRepositoryTests : StoreEntityFrameworkCoreTestBase
{
    private readonly IAddressRepository _addressRepository;

    public AddressRepositoryTests()
    {
        _addressRepository = GetRequiredService<IAddressRepository>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            // Arrange

            // Act

            //Assert
        });
    }
    */
}
