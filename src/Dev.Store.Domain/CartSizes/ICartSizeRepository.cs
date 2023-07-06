using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.CartSizes;

/// <summary>
/// 
/// </summary>
public interface ICartSizeRepository : IRepository<CartSize, Guid>
{
}
