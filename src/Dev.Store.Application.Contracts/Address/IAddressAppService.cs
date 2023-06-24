using System;
using Dev.Store.Address.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.Address;


/// <summary>
/// 
/// </summary>
public interface IAddressAppService :
    ICrudAppService< 
        AddressDto, 
        Guid, 
        AddressGetListInput,
        CreateUpdateAddressDto,
        CreateUpdateAddressDto>
{

}