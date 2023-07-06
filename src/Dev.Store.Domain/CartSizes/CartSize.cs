using Dev.Store.CartProducts;
using Dev.Store.ProductSizes;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.CartSizes
{
    public class CartSize : FullAuditedEntity<Guid>
    {
        public virtual Guid CartProductId { get; set; }
        public virtual Guid SizeId { get; set; }
        public virtual int Quantity { get; set; }

        public CartProduct CartProduct { get; set; }
        public ProductSize ProductSize { get; set; }

    protected CartSize()
    {
    }

    public CartSize(
        Guid id,
        Guid cartProductId,
        Guid sizeId,
        int quantity,
        CartProduct cartProduct,
        ProductSize productSet
    ) : base(id)
    {
        CartProductId = cartProductId;
        SizeId = sizeId;
        Quantity = quantity;
        CartProduct = cartProduct;
        ProductSize = productSet;
    }
    }
}
