using Dev.Store.OrderSets.Dtos;
using Dev.Store.OrderSizes.Dtos;
using Dev.Store.Products.Dtos;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.OrderProducts.Dtos;

/// <summary>
/// 
/// </summary>
[Serializable]
public class OrderProductDto : FullAuditedEntityDto<Guid>
{
    /// <summary>
    /// 
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ProductDto Product { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<OrderSizeDto> OrderSizes { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<OrderSetDto> OrderSets { get; set; }
}