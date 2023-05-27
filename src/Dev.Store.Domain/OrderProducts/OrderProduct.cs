using Dev.Store.OrderSets;
using Dev.Store.OrderSizes;
using Dev.Store.Products;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.OrderProducts
{
    public class OrderProduct : FullAuditedEntity<Guid>
    {
        public virtual Guid OrderId { get; set; }
        public virtual Guid ProductId { get; set; }
        public Product Product { get; set; }
        public IEnumerable<OrderSize> OrderSizes { get; set; }
        public IEnumerable<OrderSet> OrderSets { get; set; }
    }
}
