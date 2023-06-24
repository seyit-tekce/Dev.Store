using Dev.Store.OrderActions;
using Dev.Store.OrderAddress;
using Dev.Store.OrderProducts;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Dev.Store.Orders
{
    public class Order : FullAuditedAggregateRoot<Guid>
    {
        public virtual string Code { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual Guid OrderAddressId { get; set; }
        public virtual OrderMethod Method { get; set; }
        public IEnumerable<OrderProduct> Products { get; set; }
        public IEnumerable<OrderAction> OrderActions { get; set; }
        public OrderAdress OrderAddress { get; set; }
        public IdentityUser User { get; set; }

        protected Order()
        {
        }

        public Order(
            Guid id,
            string code,
            Guid userId,
            Guid orderAddressId,
            OrderMethod method,
            IEnumerable<OrderProduct> products,
            OrderAdress orderAddress
        ) : base(id)
        {
            Code = code;
            UserId = userId;
            OrderAddressId = orderAddressId;
            Method = method;
            Products = products;
            OrderAddress = orderAddress;
        }
    }
}
