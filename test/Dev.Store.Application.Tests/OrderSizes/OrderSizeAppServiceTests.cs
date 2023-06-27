using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Dev.Store.OrderSizes;

public class OrderSizeAppServiceTests : StoreApplicationTestBase
{
    private readonly IOrderSizeAppService _orderSizeAppService;

    public OrderSizeAppServiceTests()
    {
        _orderSizeAppService = GetRequiredService<IOrderSizeAppService>();
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

