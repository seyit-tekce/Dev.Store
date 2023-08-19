using Dev.Store.CartProducts;
using Dev.Store.CartProducts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Public.Pages.Cart
{
    public class IndexModel : StorePageModel
    {
        private readonly ICartProductAppService _cartProductAppService;

        [BindProperty]
        public CreateUpdateCartProductDto item { get; set; }

        public CartDto Cart { get; set; }
        public IndexModel(ICartProductAppService cartProductAppService)
        {
            _cartProductAppService = cartProductAppService;
        }
        public async Task OnGetAsync()
        {
            Request.Cookies.TryGetValue("SESSION_ID", out var sessionid);
            if (sessionid == null) { sessionid = new Guid().ToString(); }



            Cart = await _cartProductAppService.GetUserCart(new Guid(sessionid));
        }
        public async Task<IActionResult> OnPutAsync()
        {
            Request.Cookies.TryGetValue("SESSION_ID", out var sessionid);
            if (sessionid == null) { sessionid = new Guid().ToString(); }
            await _cartProductAppService.AddToChart(new CreateUpdateCartProductDto
            {
                Amount = item.Amount,
                CartSets = item.CartSets,
                CartSizes = item.CartSizes,
                ProductId = item.ProductId
            }, new Guid(sessionid));
            return NoContent();
        }
    }
}
