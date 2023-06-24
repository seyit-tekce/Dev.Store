using System;
using Dev.Store.OrderProducts;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.OrderSizes
{
    public class OrderSize : FullAuditedEntity<Guid>
    {
        public virtual Guid OrderProductId { get; set; }
        public virtual Guid SizeId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual double SizePrice { get; set; }

        public OrderProduct OrderProduct { get; set; }
        public ProductSizes.ProductSize ProductSize { get; set; }

    protected OrderSize()
    {
    }

    public OrderSize(
        Guid id,
        Guid orderProductId,
        Guid sizeId,
        int quantity,
        double sizePrice,
        OrderProduct orderProduct,
        ProductSizes.ProductSize productSize
    ) : base(id)
    {
        OrderProductId = orderProductId;
        SizeId = sizeId;
        Quantity = quantity;
        SizePrice = sizePrice;
        OrderProduct = orderProduct;
        ProductSize = productSize;
    }
    }
}
