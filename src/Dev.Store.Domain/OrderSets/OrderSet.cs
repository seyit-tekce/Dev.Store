using Dev.Store.OrderProducts;
using Dev.Store.ProductSets;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.OrderSets
{
    public class OrderSet : FullAuditedEntity<Guid>
    {
        public virtual Guid OrderProductId { get; set; }
        public virtual Guid SetId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual double SetPrice { get; set; }

        public OrderProduct OrderProduct { get; set; }
        public ProductSet ProductSet { get; set; }


    }
}
