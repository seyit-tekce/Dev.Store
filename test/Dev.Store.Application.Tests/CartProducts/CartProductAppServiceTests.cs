using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Dev.Store.CartProducts;

public class CartProductAppServiceTests : StoreApplicationTestBase
{
    private readonly ICartProductAppService _cartProductAppService;

    public CartProductAppServiceTests()
    {
        _cartProductAppService = GetRequiredService<ICartProductAppService>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        // Arrange

        // Act

        // Assert
    }
    */
}

