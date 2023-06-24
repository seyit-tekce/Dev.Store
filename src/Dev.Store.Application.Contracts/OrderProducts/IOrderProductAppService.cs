using System;
using Dev.Store.OrderProducts.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.OrderProducts;


/// <summary>
/// 
/// </summary>
public interface IOrderProductAppService :
    ICrudAppService< 
        OrderProductDto, 
        Guid, 
        OrderProductGetListInput,
        CreateUpdateOrderProductDto,
        CreateUpdateOrderProductDto>
{

}