using Dev.Store.OrderSets.Dtos;
using Dev.Store.OrderSizes.Dtos;
using Dev.Store.Products.Dtos;
using System;
using System.Collections.Generic;

namespace Dev.Store.OrderProducts.Dtos;

[Serializable]
public class CreateUpdateOrderProductDto
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