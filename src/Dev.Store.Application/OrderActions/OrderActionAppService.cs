using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.Permissions;
using Dev.Store.OrderActions.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.OrderActions;


/// <summary>
/// 
/// </summary>
public class OrderActionAppService : CrudAppService<OrderAction, OrderActionDto, Guid, OrderActionGetListInput, CreateUpdateOrderActionDto, CreateUpdateOrderActionDto>,
    IOrderActionAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.OrderAction.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.OrderAction.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.OrderAction.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.OrderAction.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.OrderAction.Delete;

    private readonly IOrderActionRepository _repository;

    public OrderActionAppService(IOrderActionRepository repository) : base(repository)
    {
        _repository = repository;
    }

    
}
