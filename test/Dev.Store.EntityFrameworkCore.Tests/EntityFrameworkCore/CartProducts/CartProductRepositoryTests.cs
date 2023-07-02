using System;
using System.Threading.Tasks;
using Dev.Store.CartProducts;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Dev.Store.EntityFrameworkCore.CartProducts;

public class CartProductRepositoryTests : StoreEntityFrameworkCoreTestBase
{
    private readonly ICartProductRepository _cartProductRepository;

    public CartProductRepositoryTests()
    {
        _cartProductRepository = GetRequiredService<ICartProductRepository>();
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
