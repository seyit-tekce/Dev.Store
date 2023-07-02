using Dev.Store.CartProducts.Dtos;
using Dev.Store.ProductSizes.Dtos;
using System;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.CartSizes.Dtos;

/// <summary>
/// 
/// </summary>
[Serializable]
public class CartSizeDto : FullAuditedEntityDto<Guid>
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
    public ProductSizeDto ProductSize { get; set; }
}