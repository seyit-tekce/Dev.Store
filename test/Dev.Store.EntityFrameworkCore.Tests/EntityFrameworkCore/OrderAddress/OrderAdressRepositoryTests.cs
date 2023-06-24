using System;
using System.Threading.Tasks;
using Dev.Store.OrderAddress;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Dev.Store.EntityFrameworkCore.OrderAddress;

public class OrderAdressRepositoryTests : StoreEntityFrameworkCoreTestBase
{
    private readonly IOrderAdressRepository _orderAdressRepository;

    public OrderAdressRepositoryTests()
    {
        _orderAdressRepository = GetRequiredService<IOrderAdressRepository>();
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
