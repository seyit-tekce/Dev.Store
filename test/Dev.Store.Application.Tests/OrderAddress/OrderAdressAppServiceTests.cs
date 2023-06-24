using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Dev.Store.OrderAddress;

public class OrderAdressAppServiceTests : StoreApplicationTestBase
{
    private readonly IOrderAdressAppService _orderAdressAppService;

    public OrderAdressAppServiceTests()
    {
        _orderAdressAppService = GetRequiredService<IOrderAdressAppService>();
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

