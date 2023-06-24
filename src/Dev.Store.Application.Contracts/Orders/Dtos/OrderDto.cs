using Dev.Store.OrderAddress.Dtos;
using Dev.Store.OrderProducts.Dtos;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.Orders.Dtos;

/// <summary>
/// 
/// </summary>
[Serializable]
public class OrderDto : FullAuditedEntityDto<Guid>
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