using System;
using System.Threading.Tasks;
using Dev.Store.CartSets;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Dev.Store.EntityFrameworkCore.CartSets;

public class CartSetRepositoryTests : StoreEntityFrameworkCoreTestBase
{
    private readonly ICartSetRepository _cartSetRepository;

    public CartSetRepositoryTests()
    {
        _cartSetRepository = GetRequiredService<ICartSetRepository>();
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
