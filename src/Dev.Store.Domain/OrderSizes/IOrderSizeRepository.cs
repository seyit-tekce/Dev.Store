using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.OrderSizes;

/// <summary>
/// 
/// </summary>
public interface IOrderSizeRepository : IRepository<OrderSize, Guid>
{
}
