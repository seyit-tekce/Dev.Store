using Dev.Store.OrderProducts.Dtos;
using Dev.Store.ProductSets.Dtos;
using System;

namespace Dev.Store.OrderSets.Dtos;

[Serializable]
public class CreateUpdateOrderSetDto
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