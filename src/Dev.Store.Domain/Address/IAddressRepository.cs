using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.Address;

/// <summary>
/// 
/// </summary>
public interface IAddressRepository : IRepository<Address, Guid>
{
}
