using Dev.Store.CartSets.Dtos;
using Dev.Store.Permissions;
using System;
using Volo.Abp.Application.Services;

namespace Dev.Store.CartSets;


/// <summary>
/// 
/// </summary>
public class CartSetAppService : CrudAppService<CartSet, CartSetDto, Guid, CartSetGetListInput, CreateUpdateCartSetDto, CreateUpdateCartSetDto>,
    ICartSetAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.CartSet.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.CartSet.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.CartSet.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.CartSet.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.CartSet.Delete;

    private readonly ICartSetRepository _repository;

    public CartSetAppService(ICartSetRepository repository) : base(repository)
    {
        _repository = repository;
    }
}
