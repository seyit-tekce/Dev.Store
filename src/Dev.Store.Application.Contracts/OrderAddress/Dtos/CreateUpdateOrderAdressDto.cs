using Dev.Store.Address.Dtos;
using System;

namespace Dev.Store.OrderAddress.Dtos;

[Serializable]
public class CreateUpdateOrderAdressDto
{
    /// <summary>
    /// 
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid AddressId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string FullAddress { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public AddressDto Address { get; set; }
}