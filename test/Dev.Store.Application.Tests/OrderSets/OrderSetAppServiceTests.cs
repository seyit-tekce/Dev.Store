using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Dev.Store.OrderSets;

public class OrderSetAppServiceTests : StoreApplicationTestBase
{
    private readonly IOrderSetAppService _orderSetAppService;

    public OrderSetAppServiceTests()
    {
        _orderSetAppService = GetRequiredService<IOrderSetAppService>();
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

