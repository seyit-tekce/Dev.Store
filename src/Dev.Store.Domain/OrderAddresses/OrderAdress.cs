using Dev.Store.Orders;
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
        public Order Order { get; set; }

    protected OrderAdress()
    {
    }

    public OrderAdress(
        Guid id,
        Guid orderId,
        Guid addressId,
        string fullName,
        string phoneNumber,
        string fullAddress,
        Address.Address address
    ) : base(id)
    {
        OrderId = orderId;
        AddressId = addressId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        FullAddress = fullAddress;
        Address = address;
    }
    }
}
