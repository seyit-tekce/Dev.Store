using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.OrderActions;

/// <summary>
/// 
/// </summary>
public interface IOrderActionRepository : IRepository<OrderAction, Guid>
{
}
