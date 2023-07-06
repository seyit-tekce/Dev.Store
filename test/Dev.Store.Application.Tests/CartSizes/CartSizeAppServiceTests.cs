using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Dev.Store.CartSizes;

public class CartSizeAppServiceTests : StoreApplicationTestBase
{
    private readonly ICartSizeAppService _cartSizeAppService;

    public CartSizeAppServiceTests()
    {
        _cartSizeAppService = GetRequiredService<ICartSizeAppService>();
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

