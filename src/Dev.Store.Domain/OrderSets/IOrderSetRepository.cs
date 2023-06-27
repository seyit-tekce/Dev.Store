using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.OrderSets;

/// <summary>
/// 
/// </summary>
public interface IOrderSetRepository : IRepository<OrderSet, Guid>
{
}
