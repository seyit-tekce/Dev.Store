using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Dev.Store.OrderActions;

public class OrderActionAppServiceTests : StoreApplicationTestBase
{
    private readonly IOrderActionAppService _orderActionAppService;

    public OrderActionAppServiceTests()
    {
        _orderActionAppService = GetRequiredService<IOrderActionAppService>();
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

