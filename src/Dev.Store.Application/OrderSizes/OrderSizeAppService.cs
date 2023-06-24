using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.Permissions;
using Dev.Store.OrderSizes.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.OrderSizes;


/// <summary>
/// 
/// </summary>
public class OrderSizeAppService : CrudAppService<OrderSize, OrderSizeDto, Guid, OrderSizeGetListInput, CreateUpdateOrderSizeDto, CreateUpdateOrderSizeDto>,
    IOrderSizeAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.OrderSize.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.OrderSize.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.OrderSize.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.OrderSize.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.OrderSize.Delete;

    private readonly IOrderSizeRepository _repository;

    public OrderSizeAppService(IOrderSizeRepository repository) : base(repository)
    {
        _repository = repository;
    }

 
}
