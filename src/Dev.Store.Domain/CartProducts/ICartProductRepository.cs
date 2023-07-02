using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.CartProducts;

/// <summary>
/// 
/// </summary>
public interface ICartProductRepository : IRepository<CartProduct, Guid>
{
    Task<IEnumerable<CartProduct>> GetUserCartAsync(Guid? userId = null, Guid? sessionId = null);
}
