using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.CartSets;

/// <summary>
/// 
/// </summary>
public interface ICartSetRepository : IRepository<CartSet, Guid>
{
}
