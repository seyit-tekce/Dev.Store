using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.Repositories;

public interface IBrandRepository : IRepository<Brand, Guid>
{
}
