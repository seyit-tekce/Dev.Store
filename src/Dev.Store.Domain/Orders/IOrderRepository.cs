using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.Orders;

/// <summary>
/// 
/// </summary>
public interface IOrderRepository : IRepository<Order, Guid>
{
}
