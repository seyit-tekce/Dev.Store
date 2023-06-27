using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.OrderProducts;

/// <summary>
/// 
/// </summary>
public interface IOrderProductRepository : IRepository<OrderProduct, Guid>
{
}
