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
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }


        if (await context.IsGrantedAsync(StorePermissions.Brand.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(StoreMenus.Brand, l["Menu:Brand"], "/Brand", "fa fa-fax")
            );
        }
        if (await context.IsGrantedAsync(StorePermissions.Category.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(StoreMenus.Category, l["Menu:Category"], "/Category", "fa fa-th")
            );
        }
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
        if (await context.IsGrantedAsync(StorePermissions.Location.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(StoreMenus.Location, l["Menu:Location"], "/Location/Location")
            );
        }
    }
}
