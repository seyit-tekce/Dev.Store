using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.ProductSets;

public interface IProductSetRepository : IRepository<ProductSet, Guid>
{
}
