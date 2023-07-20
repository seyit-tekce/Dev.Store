using Dev.Store.CartSets.Dtos;
using Dev.Store.CartSizes.Dtos;
using System;
using System.Collections.Generic;

namespace Dev.Store.CartProducts.Dtos;

[Serializable]
public class CreateUpdateCartProductDto
{
    /// <summary>
    /// 
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<CreateUpdateCartSizeDto> CartSizes { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<CreateUpdateCartSetDto> CartSets { get; set; }
}