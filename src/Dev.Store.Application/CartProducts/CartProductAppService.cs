using Dev.Store.CartProducts.Dtos;
using Dev.Store.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dev.Store.CartProducts;

[AllowAnonymous]
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
    [AllowAnonymous]
    public async Task<CartDto> GetUserCart(Guid? sessionId = null)
    {
        var res = await _repository.GetUserCartAsync(CurrentUser.Id, sessionId);
        return ObjectMapper.Map<IEnumerable<CartProduct>, CartDto>(res);
    }
    public override Task<CartProductDto> CreateAsync(CreateUpdateCartProductDto input)
    {
        return base.CreateAsync(input);
    }


    [AllowAnonymous]
    public async Task AddToChart(CreateUpdateCartProductDto input, Guid? sessionid)
    {

        var map = ObjectMapper.Map<CreateUpdateCartProductDto, CartProduct>(input);
        if (sessionid.HasValue)
        {
            map.SessionId = sessionid.Value;

        }
        var userChart = await GetUserCart(sessionid);

        var hasProduct = userChart.Products.Any(x => x.ProductId == input.ProductId);

        if (hasProduct)
        {
            var product = await _repository.FindAsync(x => x.ProductId == input.ProductId && x.SessionId == sessionid || (x.CreatorId == CurrentUser.Id && x.CreatorId != null));
            product.Amount = product.Amount + input.Amount;
            await _repository.UpdateAsync(product);

        }
        else
        {
            await _repository.InsertAsync(map);

        }



    }

}