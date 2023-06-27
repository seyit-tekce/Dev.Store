using System;
using Dev.Store.Orders.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.Orders;


/// <summary>
/// 
/// </summary>
public interface IOrderAppService :
    ICrudAppService< 
        OrderDto, 
        Guid, 
        OrderGetListInput,
        CreateUpdateOrderDto,
        CreateUpdateOrderDto>
{

}