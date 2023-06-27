using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Dev.Store.OrderProducts;

public class OrderProductAppServiceTests : StoreApplicationTestBase
{
    private readonly IOrderProductAppService _orderProductAppService;

    public OrderProductAppServiceTests()
    {
        _orderProductAppService = GetRequiredService<IOrderProductAppService>();
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

