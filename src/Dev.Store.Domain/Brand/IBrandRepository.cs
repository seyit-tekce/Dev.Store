using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.Brand;

public interface IBrandRepository : IRepository<Brand, Guid>
{
}
