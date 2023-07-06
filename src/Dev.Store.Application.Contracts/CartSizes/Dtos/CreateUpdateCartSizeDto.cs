using Dev.Store.CartProducts.Dtos;
using Dev.Store.ProductSizes.Dtos;
using System;

namespace Dev.Store.CartSizes.Dtos;

[Serializable]
public class CreateUpdateCartSizeDto
{
    /// <summary>
    /// 
    /// </summary>
    public Guid CartProductId { get; set; }

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
    public CartProductDto CartProduct { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ProductSizeDto ProductSet { get; set; }
}