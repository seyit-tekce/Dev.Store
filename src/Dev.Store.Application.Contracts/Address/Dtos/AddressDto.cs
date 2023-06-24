using Dev.Store.Locations.Dtos;
using System;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.Address.Dtos;

/// <summary>
/// 
/// </summary>
[Serializable]
public class AddressDto : AuditedEntityDto<Guid>
{
    /// <summary>
    /// 
    /// </summary>
    public string AddressName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string FullAddress { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid CityId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public LocationDto City { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid TownId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public LocationDto Town { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int PostalCode { get; set; }
}