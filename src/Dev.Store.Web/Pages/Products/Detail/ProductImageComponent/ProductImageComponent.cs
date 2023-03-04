using Microsoft.AspNetCore.Mvc;
using System;
using Volo.Abp.AspNetCore.Mvc;

namespace Dev.Store.Web.Pages.Products.Detail.ProductImageComponent
{
    public class ProductImageComponent : AbpViewComponent
    {
        public ProductImageComponent()
        {

        }

        public IViewComponentResult Invoke(Guid productId)
        {
            return View("/Pages/Products/Detail/ProductImageComponent/ProductImageComponent.cshtml", productId);
        }
    }
}
