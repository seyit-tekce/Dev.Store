using Dev.Store.Order;
using Dev.Store.OrderAddress;
using Dev.Store.OrderProducts;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.Orders
{
    public class Order : FullAuditedAggregateRoot<Guid>
    {
        public virtual string Code { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual Guid OrderAddressId { get; set; }
        public virtual OrderMethod Method { get; set; }
        public IEnumerable<OrderProduct> Products { get; set; }
        public OrderAdress OrderAddress { get; set; }
    }
}
