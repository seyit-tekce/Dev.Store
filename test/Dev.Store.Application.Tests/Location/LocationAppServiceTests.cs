using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Dev.Store.Location;

public class LocationAppServiceTests : StoreApplicationTestBase
{
    private readonly ILocationAppService _locationAppService;

    public LocationAppServiceTests()
    {
        _locationAppService = GetRequiredService<ILocationAppService>();
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

