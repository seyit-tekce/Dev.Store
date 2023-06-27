using System;
using System.Threading.Tasks;
using Dev.Store.OrderActions;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Dev.Store.EntityFrameworkCore.OrderActions;

public class OrderActionRepositoryTests : StoreEntityFrameworkCoreTestBase
{
    private readonly IOrderActionRepository _orderActionRepository;

    public OrderActionRepositoryTests()
    {
        _orderActionRepository = GetRequiredService<IOrderActionRepository>();
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
