using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.ProductImages;

public interface IProductImageRepository : IRepository<ProductImage, Guid>
{
}
