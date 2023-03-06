using Microsoft.AspNetCore.Mvc;
using System;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Dev.Store.Web.Pages.Products.Detail.Components.ProductImageComponent;

[Widget(
        ScriptFiles = new[] { "/Pages/Products/Detail/Components/ProductImageComponent/ProductImageComponent.js" }
        )]
public class ProductImageComponent : AbpViewComponent
{
    public ProductImageComponent()
    {

    }

    public IViewComponentResult Invoke(Guid productId)
    {
        return View(@"ProductImageComponent.cshtml", productId);
    }
}
