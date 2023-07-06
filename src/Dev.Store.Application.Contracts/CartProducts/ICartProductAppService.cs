using Dev.Store.CartProducts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dev.Store.CartProducts;


/// <summary>
/// 
/// </summary>
public interface ICartProductAppService :
    ICrudAppService<
        CartProductDto,
        Guid,
        CartProductDto,
        CreateUpdateCartProductDto,
        CreateUpdateCartProductDto>
{

    Task<CartDto> GetUserCart(Guid? userId = null, Guid? sessionId = null);
}