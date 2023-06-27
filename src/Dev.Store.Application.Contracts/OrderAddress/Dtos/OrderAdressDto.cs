using Dev.Store.Address.Dtos;
using System;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.OrderAddress.Dtos;

/// <summary>
/// 
/// </summary>
[Serializable]
public class OrderAdressDto : FullAuditedEntityDto<Guid>
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