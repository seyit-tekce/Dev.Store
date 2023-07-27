using Dev.Store.CartSets.Dtos;
using Dev.Store.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dev.Store.CartSets;

[AllowAnonymous]
public class CartSetAppService : CrudAppService<CartSet, CartSetDto, Guid, CartSetGetListInput, CreateUpdateCartSetDto, CreateUpdateCartSetDto>,
    ICartSetAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.CartSet.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.CartSet.Default;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.CartSet.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.CartSet.Delete;

    private readonly ICartSetRepository _repository;

    public CartSetAppService(ICartSetRepository repository) : base(repository)
    {
        _repository = repository;
    }
}
