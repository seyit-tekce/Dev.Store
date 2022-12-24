using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store;

public interface IBrandRepository : IRepository<Brand, Guid>
{
}
