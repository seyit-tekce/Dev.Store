using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.Brands;

public interface IBrandRepository : IRepository<Brand, Guid>
{
}
