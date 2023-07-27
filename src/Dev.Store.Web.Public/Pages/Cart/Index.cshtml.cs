using Dev.Store.CartProducts;
using Dev.Store.CartProducts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Public.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly ICartProductAppService _cartProductAppService;
        public CartDto Cart { get; set; }
        public IndexModel(ICartProductAppService cartProductAppService)
        {
            _cartProductAppService = cartProductAppService;
        }

        public async Task OnGetAsync()
        {
            var sessionId = HttpContext.Session.GetString("sessionId");
            if (sessionId == null)
            {
                sessionId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("sessionId", sessionId);
            }
            Cart = await _cartProductAppService.GetUserCart(new Guid(sessionId));
        }
    }
}
