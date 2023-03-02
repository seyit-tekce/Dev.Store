using System.Threading.Tasks;
using Dev.Store.Permissions;
using Dev.Store.Localization;
using Dev.Store.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Dev.Store.Web.Public.Menus;

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

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
        if (await context.IsGrantedAsync(StorePermissions.Keyword.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(StoreMenus.Keyword, l["Menu:Keyword"], "/Keywords/Keyword")
            );
        }
        if (await context.IsGrantedAsync(StorePermissions.CloudinarySetting.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(StoreMenus.CloudinarySetting, l["Menu:CloudinarySetting"], "/CloudinarySettings/CloudinarySetting")
            );
        }
        if (await context.IsGrantedAsync(StorePermissions.UploadFile.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(StoreMenus.UploadFile, l["Menu:UploadFile"], "/UploadFiles/UploadFile")
            );
        }
        if (await context.IsGrantedAsync(StorePermissions.Product.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(StoreMenus.Product, l["Menu:Product"], "/Products/Product")
            );
        }
        if (await context.IsGrantedAsync(StorePermissions.ProductSet.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(StoreMenus.ProductSet, l["Menu:ProductSet"], "/ProductSets/ProductSet")
            );
        }
        if (await context.IsGrantedAsync(StorePermissions.ProductSize.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(StoreMenus.ProductSize, l["Menu:ProductSize"], "/ProductSizes/ProductSize")
            );
        }
        if (await context.IsGrantedAsync(StorePermissions.SeoSetting.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(StoreMenus.SeoSetting, l["Menu:SeoSetting"], "/SeoSettings/SeoSetting")
            );
        }
        if (await context.IsGrantedAsync(StorePermissions.ProductImage.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(StoreMenus.ProductImage, l["Menu:ProductImage"], "/ProductImages/ProductImage")
            );
        }
    }
}
