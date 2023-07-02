using Dev.Store.CartProducts;
using Dev.Store.OrderProducts;
using Dev.Store.ProductSets;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.CartSets
{
    public class CartSet : FullAuditedEntity<Guid>
    {
        public virtual Guid CartProductId { get; set; }
        public virtual Guid SetId { get; set; }
        public virtual int Quantity { get; set; }

        public CartProduct CartProduct { get; set; }
        public ProductSet ProductSet { get; set; }


    protected CartSet()
    {
    }

    public CartSet(
        Guid id,
        Guid cartProductId,
        Guid setId,
        int quantity,
        CartProduct cartProduct,
        ProductSet productSet
    ) : base(id)
    {
        CartProductId = cartProductId;
        SetId = setId;
        Quantity = quantity;
        CartProduct = cartProduct;
        ProductSet = productSet;
    }
    }
}
