using System;
using Dev.Store.OrderActions.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.OrderActions;


/// <summary>
/// 
/// </summary>
public interface IOrderActionAppService :
    ICrudAppService< 
        OrderActionDto, 
        Guid, 
        OrderActionGetListInput,
        CreateUpdateOrderActionDto,
        CreateUpdateOrderActionDto>
{

}