using Dev.Store.CartProducts.Dtos;
using Dev.Store.ProductSets.Dtos;
using System;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.CartSets.Dtos;

/// <summary>
/// 
/// </summary>
[Serializable]
public class CartSetDto : FullAuditedEntityDto<Guid>
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