using System;
using Dev.Store.OrderSets.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.OrderSets;


/// <summary>
/// 
/// </summary>
public interface IOrderSetAppService :
    ICrudAppService< 
        OrderSetDto, 
        Guid, 
        OrderSetGetListInput,
        CreateUpdateOrderSetDto,
        CreateUpdateOrderSetDto>
{

}