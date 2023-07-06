using Dev.Store.CartProducts.Dtos;
using Dev.Store.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Security.Claims;

namespace Dev.Store.CartProducts;

[RemoteService(Name = "Default")]
[Route("/api/app/cart")]
public class CartController : StoreController
{
    private readonly ICartProductAppService _service;
    private readonly ICurrentPrincipalAccessor _currentPrincipalAccessor;
    public CartController(ICartProductAppService service, ICurrentPrincipalAccessor currentPrincipalAccessor)
    {
        _service = service;
        _currentPrincipalAccessor = currentPrincipalAccessor;
    }

    [HttpGet]
    [Route("user-cart")]
    public virtual Task<CartDto> GetUserCart()
    {
        var sessionId = _currentPrincipalAccessor.Principal.GetClaim("sessionId");
        if (sessionId == null)
        {
            sessionId = Guid.NewGuid().ToString();
            _currentPrincipalAccessor.Principal.AddClaim("sessionId", sessionId);
        }
        return _service.GetUserCart(CurrentUser.Id, new Guid(sessionId));
    }
}