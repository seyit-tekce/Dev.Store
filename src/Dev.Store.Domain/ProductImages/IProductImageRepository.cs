using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.ProductImages;

public interface IProductImageRepository : IRepository<ProductImage, Guid>
{
    Task<IEnumerable<ProductImage>> GetAllMainByProductIdAsync(IEnumerable<Guid> productIds);
}
