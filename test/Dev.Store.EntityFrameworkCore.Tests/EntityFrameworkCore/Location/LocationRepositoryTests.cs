using System;
using System.Threading.Tasks;
using Dev.Store.Location;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Dev.Store.EntityFrameworkCore.Location;

public class LocationRepositoryTests : StoreEntityFrameworkCoreTestBase
{
    private readonly ILocationRepository _locationRepository;

    public LocationRepositoryTests()
    {
        _locationRepository = GetRequiredService<ILocationRepository>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            // Arrange

            // Act

            //Assert
        });
    }
    */
}
