using Dev.Store.Locations;
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

    protected Address()
    {
    }

    public Address(
        Guid id,
        string addressName,
        string firstName,
        string lastName,
        string phoneNumber,
        string email,
        string fullAddress,
        Guid cityId,
        Location city,
        Guid townId,
        Location town,
        int postalCode
    ) : base(id)
    {
        AddressName = addressName;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
        FullAddress = fullAddress;
        CityId = cityId;
        City = city;
        TownId = townId;
        Town = town;
        PostalCode = postalCode;
    }
    }
}
