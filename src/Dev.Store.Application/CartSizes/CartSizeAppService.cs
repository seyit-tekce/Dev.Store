using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.Permissions;
using Dev.Store.CartSizes.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.CartSizes;


/// <summary>
/// 
/// </summary>
public class CartSizeAppService : CrudAppService<CartSize, CartSizeDto, Guid, CartSizeGetListInput, CreateUpdateCartSizeDto, CreateUpdateCartSizeDto>,
    ICartSizeAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.CartSize.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.CartSize.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.CartSize.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.CartSize.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.CartSize.Delete;

    private readonly ICartSizeRepository _repository;

    public CartSizeAppService(ICartSizeRepository repository) : base(repository)
    {
        _repository = repository;
    }

}
