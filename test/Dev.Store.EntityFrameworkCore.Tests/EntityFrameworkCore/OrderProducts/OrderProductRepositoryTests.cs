using System;
using System.Threading.Tasks;
using Dev.Store.OrderProducts;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Dev.Store.EntityFrameworkCore.OrderProducts;

public class OrderProductRepositoryTests : StoreEntityFrameworkCoreTestBase
{
    private readonly IOrderProductRepository _orderProductRepository;

    public OrderProductRepositoryTests()
    {
        _orderProductRepository = GetRequiredService<IOrderProductRepository>();
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
