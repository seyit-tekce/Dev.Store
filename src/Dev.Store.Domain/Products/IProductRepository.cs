using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.Products;

public interface IProductRepository : IRepository<Product, Guid>
{
}
