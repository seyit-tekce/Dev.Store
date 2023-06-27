using Dev.Store.Orders;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.OrderActions
{
    public class OrderAction : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid OrderId { get; set; }
        public virtual OrderActionStatus Status { get; set; }
        public virtual string Note { get; set; }
        public Order Order { get; set; }



    protected OrderAction()
    {
    }

    public OrderAction(
        Guid id,
        Guid orderId,
        OrderActionStatus status,
        string note
    ) : base(id)
    {
        OrderId = orderId;
        Status = status;
        Note = note;
    }
    }
}
