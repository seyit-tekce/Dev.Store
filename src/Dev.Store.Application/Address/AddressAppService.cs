using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.Permissions;
using Dev.Store.Address.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.Address;


/// <summary>
/// 
/// </summary>
public class AddressAppService : CrudAppService<Address, AddressDto, Guid, AddressGetListInput, CreateUpdateAddressDto, CreateUpdateAddressDto>,
    IAddressAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.Address.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.Address.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.Address.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.Address.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.Address.Delete;

    private readonly IAddressRepository _repository;

    public AddressAppService(IAddressRepository repository) : base(repository)
    {
        _repository = repository;
    }

   
}
