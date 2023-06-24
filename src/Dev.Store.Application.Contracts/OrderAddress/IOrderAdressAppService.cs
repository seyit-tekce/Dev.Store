using System;
using Dev.Store.OrderAddress.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.OrderAddress;


/// <summary>
/// 
/// </summary>
public interface IOrderAdressAppService :
    ICrudAppService< 
        OrderAdressDto, 
        Guid, 
        OrderAdressGetListInput,
        CreateUpdateOrderAdressDto,
        CreateUpdateOrderAdressDto>
{

}