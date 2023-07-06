using Dev.Store.CartSets.Dtos;
using Dev.Store.CartSizes.Dtos;
using Dev.Store.Products.Dtos;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.CartProducts.Dtos;

/// <summary>
/// 
/// </summary>
[Serializable]
public class CartProductDto : FullAuditedEntityDto<Guid>
{
    /// <summary>
    /// 
    /// </summary>
    public Guid ProductId { get; set; }
    public Guid SessionId { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ProductDto Product { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<CartSizeDto> CartSizes { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<CartSetDto> CartSets { get; set; }
}



