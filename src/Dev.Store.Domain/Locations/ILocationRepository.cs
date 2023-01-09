using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.Locations;

public interface ILocationRepository : IRepository<Location, Guid>
{
}
