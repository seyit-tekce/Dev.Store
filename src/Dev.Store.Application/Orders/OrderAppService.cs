using Dev.Store.Orders.Dtos;
using Dev.Store.Permissions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dev.Store.Orders;


/// <summary>
/// 
/// </summary>
public class OrderAppService : CrudAppService<Order, OrderDto, Guid, OrderGetListInput, CreateUpdateOrderDto, CreateUpdateOrderDto>,
    IOrderAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.Order.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.Order.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.Order.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.Order.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.Order.Delete;

    private readonly IOrderRepository _repository;

    public OrderAppService(IOrderRepository repository) : base(repository)
    {
        _repository = repository;
    }

 
}
