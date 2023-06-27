using Dev.Store.OrderAddress.Dtos;
using Dev.Store.OrderProducts.Dtos;
using System;
using System.Collections.Generic;

namespace Dev.Store.Orders.Dtos;

[Serializable]
public class CreateUpdateOrderDto
{
    /// <summary>
    /// 
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid OrderAddressId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public OrderMethod Method { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<OrderProductDto> Products { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public OrderAdressDto OrderAddress { get; set; }
}