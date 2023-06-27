using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.OrderAddress;

/// <summary>
/// 
/// </summary>
public interface IOrderAdressRepository : IRepository<OrderAdress, Guid>
{
}
