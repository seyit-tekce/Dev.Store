using System;
using System.Threading.Tasks;
using Dev.Store.OrderSizes;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Dev.Store.EntityFrameworkCore.OrderSizes;

public class OrderSizeRepositoryTests : StoreEntityFrameworkCoreTestBase
{
    private readonly IOrderSizeRepository _orderSizeRepository;

    public OrderSizeRepositoryTests()
    {
        _orderSizeRepository = GetRequiredService<IOrderSizeRepository>();
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
