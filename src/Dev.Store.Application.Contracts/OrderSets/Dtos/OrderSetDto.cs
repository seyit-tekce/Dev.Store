using Dev.Store.OrderProducts.Dtos;
using Dev.Store.ProductSets.Dtos;
using System;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.OrderSets.Dtos;

/// <summary>
/// 
/// </summary>
[Serializable]
public class OrderSetDto : FullAuditedEntityDto<Guid>
{
    /// <summary>
    /// 
    /// </summary>
    public Guid OrderProductId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid SetId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public double SetPrice { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public OrderProductDto OrderProduct { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ProductSetDto ProductSet { get; set; }
}