using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.Permissions;
using Dev.Store.OrderAddress.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.OrderAddress;


/// <summary>
/// 
/// </summary>
public class OrderAdressAppService : CrudAppService<OrderAdress, OrderAdressDto, Guid, OrderAdressGetListInput, CreateUpdateOrderAdressDto, CreateUpdateOrderAdressDto>,
    IOrderAdressAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.OrderAdress.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.OrderAdress.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.OrderAdress.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.OrderAdress.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.OrderAdress.Delete;

    private readonly IOrderAdressRepository _repository;

    public OrderAdressAppService(IOrderAdressRepository repository) : base(repository)
    {
        _repository = repository;
    }

   
}
