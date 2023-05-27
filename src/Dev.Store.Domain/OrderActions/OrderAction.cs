using Dev.Store.Order;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.OrderActions
{
    public class OrderAction : FullAuditedAggregateRoot<Guid>
    {
        public Guid OrderId { get; set; }
        public OrderActionStatus Status { get; set; }
        public string Note { get; set; }


    }
}
