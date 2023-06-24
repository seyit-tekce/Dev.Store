using System;
using Dev.Store.OrderSizes.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.OrderSizes;


/// <summary>
/// 
/// </summary>
public interface IOrderSizeAppService :
    ICrudAppService< 
        OrderSizeDto, 
        Guid, 
        OrderSizeGetListInput,
        CreateUpdateOrderSizeDto,
        CreateUpdateOrderSizeDto>
{

}