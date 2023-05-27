using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.OrderAddress
{
    public class OrderAdress : FullAuditedEntity<Guid>
    {
        public virtual Guid OrderId { get; set; }
        public virtual Guid AddressId { get; set; }
        public virtual string FullName { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string FullAddress { get; set; }

        public Address.Address Address { get; set; }
    }
}
