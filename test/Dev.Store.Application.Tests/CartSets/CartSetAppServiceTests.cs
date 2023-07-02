using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Dev.Store.CartSets;

public class CartSetAppServiceTests : StoreApplicationTestBase
{
    private readonly ICartSetAppService _cartSetAppService;

    public CartSetAppServiceTests()
    {
        _cartSetAppService = GetRequiredService<ICartSetAppService>();
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

