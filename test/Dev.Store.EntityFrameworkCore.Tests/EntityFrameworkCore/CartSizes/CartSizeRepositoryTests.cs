using System;
using System.Threading.Tasks;
using Dev.Store.CartSizes;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Dev.Store.EntityFrameworkCore.CartSizes;

public class CartSizeRepositoryTests : StoreEntityFrameworkCoreTestBase
{
    private readonly ICartSizeRepository _cartSizeRepository;

    public CartSizeRepositoryTests()
    {
        _cartSizeRepository = GetRequiredService<ICartSizeRepository>();
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
