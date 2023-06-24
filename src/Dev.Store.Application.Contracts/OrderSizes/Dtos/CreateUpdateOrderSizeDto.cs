using Dev.Store.OrderProducts.Dtos;
using Dev.Store.ProductSizes.Dtos;
using System;

namespace Dev.Store.OrderSizes.Dtos;

[Serializable]
public class CreateUpdateOrderSizeDto
{
    /// <summary>
    /// 
    /// </summary>
    public Guid OrderProductId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid SizeId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public double SizePrice { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public OrderProductDto OrderProduct { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ProductSizeDto ProductSize { get; set; }
}