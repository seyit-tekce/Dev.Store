using System;
using System.Threading.Tasks;
using Dev.Store.OrderSets;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Dev.Store.EntityFrameworkCore.OrderSets;

public class OrderSetRepositoryTests : StoreEntityFrameworkCoreTestBase
{
    private readonly IOrderSetRepository _orderSetRepository;

    public OrderSetRepositoryTests()
    {
        _orderSetRepository = GetRequiredService<IOrderSetRepository>();
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
