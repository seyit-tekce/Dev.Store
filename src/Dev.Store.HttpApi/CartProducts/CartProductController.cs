using Dev.Store.CartProducts.Dtos;
using Dev.Store.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;

namespace Dev.Store.CartProducts;

[RemoteService(Name = "Default")]
[Route("/api/app/cart")]
public class CartController : StoreController
{
    private readonly ICartProductAppService _service;

    public CartController(ICartProductAppService service)
    {
        _service = service;
    }


    [HttpPost]
    [Route("add-to-cart")]
    public virtual async Task AddToCart(CreateUpdateCartProductDto item)
    {
        var sessionId = HttpContext.Session.GetString("sessionId");
        if (sessionId == null)
        {
            sessionId = Guid.NewGuid().ToString();
            HttpContext.Session.SetString("sessionId", sessionId);
        }

        await _service.AddToChart(new CreateUpdateCartProductDto
        {
            Amount = item.Amount,
            CartSets = item.CartSets,
            CartSizes = item.CartSizes,
            ProductId = item.ProductId
        }, new Guid(sessionId));

    }
}