using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Layout;

namespace Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart.Themes.Multikart.Components.BreadCrumb
{
    public class BreadCrumbViewComponent : AbpViewComponent
    {
        protected IPageLayout PageLayout { get; }

        public BreadCrumbViewComponent(IPageLayout pageLayout)
        {
            PageLayout = pageLayout;
        }

        public virtual IViewComponentResult Invoke()
        {
            return View("~/Themes/Multikart/Components/BreadCrumb/Default.cshtml", PageLayout.Content);
        }
    }
}
