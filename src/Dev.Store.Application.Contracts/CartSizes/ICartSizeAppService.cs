using System;
using Dev.Store.CartSizes.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.CartSizes;


/// <summary>
/// 
/// </summary>
public interface ICartSizeAppService :
    ICrudAppService< 
        CartSizeDto, 
        Guid, 
        CartSizeGetListInput,
        CreateUpdateCartSizeDto,
        CreateUpdateCartSizeDto>
{

}