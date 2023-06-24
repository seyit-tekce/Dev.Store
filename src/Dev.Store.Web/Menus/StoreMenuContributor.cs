using Dev.Store.Localization;
using Dev.Store.MultiTenancy;
using Dev.Store.Permissions;
using System.Threading.Tasks;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Dev.Store.Web.Menus;

public class StoreMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        administration.Order = int.MaxValue;
        var l = context.GetLocalizer<StoreResource>();
        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                StoreMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );
        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 49);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }
        if (await context.IsGrantedAsync(StorePermissions.Brand.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(StoreMenus.Brand, l["Menu:Brand"], "/Brands", "fa fa-fax")
            );
        }
        if (await context.IsGrantedAsync(StorePermissions.Category.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(StoreMenus.Category, l["Menu:Category"], "/Categories", "fa fa-th", 1)
            );
        }
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 2);
        if (await context.IsGrantedAsync(StorePermissions.Location.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(StoreMenus.Location, l["Menu:Location"], "/Locations", "fa fa-map-marker")
            );
        }
        if (await context.IsGrantedAsync(StorePermissions.Keyword.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(StoreMenus.Keyword, l["Menu:Keyword"], "/Keywords", "fa fa-key")
            );
        }

        if (await context.IsGrantedAsync(StorePermissions.Product.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(StoreMenus.Product, l["Menu:Product"], "/Products", "fa-solid fa-couch")
            );
        }
        if (await context.IsGrantedAsync(StorePermissions.HomeSlider.Default))
        {
            var homeSettings = new ApplicationMenuItem(StoreMenus.HomeSettings, l["Menu:HomeSettings"], null, "fa fa-home");

            homeSettings.AddItem(new ApplicationMenuItem(StoreMenus.HomeSlider, l["Menu:HomeSliderType:0"], "/HomeSliders?type=0", "fa fa-sliders"));
            homeSettings.AddItem(new ApplicationMenuItem(StoreMenus.HomeSlider, l["Menu:HomeSliderType:1"], "/HomeSliders?type=1", "fa fa-sliders"));
            homeSettings.AddItem(new ApplicationMenuItem(StoreMenus.HomeSlider, l["Menu:HomeSliderType:2"], "/HomeSliders?type=2", "fa fa-sliders"));
            context.Menu.GetAdministration().AddItem(homeSettings);

        }
        if (await context.IsGrantedAsync(StorePermissions.Order.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(StoreMenus.Order, l["Menu:Order"], "/Orders/Order")
            );
        }
    }
}
