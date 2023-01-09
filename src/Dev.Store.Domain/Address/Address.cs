using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.Address
{
    public class Address : AuditedEntity<Guid>
    {
        public string AddressName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FullAddress { get; set; }
        public Guid CityId { get; set; }
        public virtual Location City { get; set; }
        public Guid TownId { get; set; }
        public virtual Location Town { get; set; }
        public int PostalCode { get; set; }
    }
}