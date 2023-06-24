using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;

namespace Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart.Themes.MultiKart.Components.Toolbar.Cart;

public class CartViewComponent : AbpViewComponent
{
    protected ILanguageProvider LanguageProvider { get; }

    public CartViewComponent(ILanguageProvider languageProvider)
    {
        LanguageProvider = languageProvider;
    }

    public virtual async Task<IViewComponentResult> InvokeAsync()
    {
        await Task.CompletedTask;
        return View("~/Themes/Multikart/Components/Toolbar/Cart/Default.cshtml");
    }
}
