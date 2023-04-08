using Dev.Store.Products;
using Dev.Store.Products.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
namespace Dev.Store.Web.Public.Pages.IndexComponents.TabProductComponent
{
    public class TabProductComponent : AbpViewComponent
    {
        private readonly IProductAppService _productAppService;
        public TabProductComponent(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new TabProductComponentModel();
            model.NewProducts = await _productAppService.GetNewProducts();
            model.BestSellers = await _productAppService.GetBestSellerProducts();
            return View("~/Pages/IndexComponents/TabProductComponent/Default.cshtml", model);
        }
    }
    public class TabProductComponentModel
    {
        public IEnumerable<ProductGridListDto> NewProducts { get; set; }
        public IEnumerable<ProductGridListDto> BestSellers { get; set; }
    }
}
