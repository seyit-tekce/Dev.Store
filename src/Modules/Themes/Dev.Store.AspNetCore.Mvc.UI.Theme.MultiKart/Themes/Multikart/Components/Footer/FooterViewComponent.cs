using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.UI.Navigation;

namespace Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart.Themes.Multikart.Components.Footer
{
    public class FooterViewComponent : AbpViewComponent
    {
        protected IMenuManager MenuManager { get; }

        public FooterViewComponent(IMenuManager menuManager)
        {
            MenuManager = menuManager;
        }
        public virtual async Task<IViewComponentResult> InvokeAsync()
        {
            var menu = await MenuManager.GetMainMenuAsync();
            return View("~/Themes/Multikart/Components/Footer/Default.cshtml", menu);
        }
    }
}