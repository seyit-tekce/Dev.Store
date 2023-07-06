using Dev.Store.CartProducts.Dtos;
using Dev.Store.ProductSets.Dtos;
using System;

namespace Dev.Store.CartSets.Dtos;

[Serializable]
public class CreateUpdateCartSetDto
{
    /// <summary>
    /// 
    /// </summary>
    public Guid CartProductId { get; set; }

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
    public CartProductDto CartProduct { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ProductSetDto ProductSet { get; set; }
}