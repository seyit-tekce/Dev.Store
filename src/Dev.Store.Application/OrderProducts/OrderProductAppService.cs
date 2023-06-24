using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.Permissions;
using Dev.Store.OrderProducts.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.OrderProducts;


/// <summary>
/// 
/// </summary>
public class OrderProductAppService : CrudAppService<OrderProduct, OrderProductDto, Guid, OrderProductGetListInput, CreateUpdateOrderProductDto, CreateUpdateOrderProductDto>,
    IOrderProductAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.OrderProduct.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.OrderProduct.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.OrderProduct.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.OrderProduct.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.OrderProduct.Delete;

    private readonly IOrderProductRepository _repository;

    public OrderProductAppService(IOrderProductRepository repository) : base(repository)
    {
        _repository = repository;
    }

   
}
