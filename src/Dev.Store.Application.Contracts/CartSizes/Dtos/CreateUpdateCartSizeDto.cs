using Dev.Store.CartProducts.Dtos;
using Dev.Store.ProductSizes.Dtos;
using System;

namespace Dev.Store.CartSizes.Dtos;

[Serializable]
public class CreateUpdateCartSizeDto
{
    public Guid SizeId { get; set; }

    public int Quantity { get; set; }
}