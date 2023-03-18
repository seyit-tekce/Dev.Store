using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.ProductSizes;

public interface IProductSizeRepository : IRepository<ProductSize, Guid>
{
    Task<IEnumerable<ProductSize>> GetAllByProductIdAsync(IEnumerable<Guid> productIds);

}
