using Dev.Store.CartProducts.Dtos;
using Dev.Store.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dev.Store.CartProducts;


public class CartProductAppService : CrudAppService<CartProduct, CartProductDto, Guid, CartProductDto, CreateUpdateCartProductDto, CreateUpdateCartProductDto>,
    ICartProductAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.CartProduct.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.CartProduct.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.CartProduct.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.CartProduct.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.CartProduct.Delete;
    private readonly ICartProductRepository _repository;

    public CartProductAppService(ICartProductRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<CartDto> GetUserCart(Guid? userId = null, Guid? sessionId = null)
    {
        var res = await _repository.GetUserCartAsync(userId, sessionId);
        return ObjectMapper.Map<IEnumerable<CartProduct>, CartDto>(res);
    }
    public override Task<CartProductDto> CreateAsync(CreateUpdateCartProductDto input)
    {
        return base.CreateAsync(input);
    }
    [AllowAnonymous]

    public async Task AddToChart(CreateUpdateCartProductDto input)
    {
        var map = ObjectMapper.Map<CreateUpdateCartProductDto, CartProduct>(input);
        await _repository.InsertAsync(map);
    }

}