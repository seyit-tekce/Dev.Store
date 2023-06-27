using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Dev.Store.Address;

public class AddressAppServiceTests : StoreApplicationTestBase
{
    private readonly IAddressAppService _addressAppService;

    public AddressAppServiceTests()
    {
        _addressAppService = GetRequiredService<IAddressAppService>();
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

