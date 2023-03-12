using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.UI.Navigation;

namespace Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart.Themes.Multikart.Components.SideNavbar
{
    public class SideNavbarMenuViewComponent : AbpViewComponent
    {
        protected IMenuManager MenuManager { get; }

        public SideNavbarMenuViewComponent(IMenuManager menuManager)
        {
            MenuManager = menuManager;
        }

        public virtual async Task<IViewComponentResult> InvokeAsync()
        {
            var menu = await MenuManager.GetMainMenuAsync();
            return View("~/Themes/Multikart/Components/SideNavbarMenu/Default.cshtml", menu);
        }
    }
}

