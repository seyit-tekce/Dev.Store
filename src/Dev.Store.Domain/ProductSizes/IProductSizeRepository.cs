using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.ProductSizes;

public interface IProductSizeRepository : IRepository<ProductSize, Guid>
{
}
