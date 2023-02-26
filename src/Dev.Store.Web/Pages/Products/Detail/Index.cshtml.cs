using Dev.Store.Products;
using Dev.Store.Products.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.Products.Detail
{
    public class IndexModel : PageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }


        private readonly IProductAppService _productAppService;
        public IndexModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        public ProductDto Product { get; set; }
        public async Task OnGet()
        {
            this.Product = await _productAppService.GetAsync(Id);
        }
    }
}
