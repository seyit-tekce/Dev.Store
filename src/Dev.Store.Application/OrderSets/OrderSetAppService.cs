using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.Permissions;
using Dev.Store.OrderSets.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.OrderSets;


/// <summary>
/// 
/// </summary>
public class OrderSetAppService : CrudAppService<OrderSet, OrderSetDto, Guid, OrderSetGetListInput, CreateUpdateOrderSetDto, CreateUpdateOrderSetDto>,
    IOrderSetAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.OrderSet.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.OrderSet.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.OrderSet.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.OrderSet.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.OrderSet.Delete;

    private readonly IOrderSetRepository _repository;

    public OrderSetAppService(IOrderSetRepository repository) : base(repository)
    {
        _repository = repository;
    }

  
}
