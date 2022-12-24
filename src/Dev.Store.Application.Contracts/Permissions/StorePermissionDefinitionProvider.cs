using Dev.Store.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Dev.Store.Permissions;

public class StorePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(StorePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(StorePermissions.MyPermission1, L("Permission:MyPermission1"));

        var brandPermission = myGroup.AddPermission(StorePermissions.Brand.Default, L("Permission:Brand"));
        brandPermission.AddChild(StorePermissions.Brand.Create, L("Permission:Create"));
        brandPermission.AddChild(StorePermissions.Brand.Update, L("Permission:Update"));
        brandPermission.AddChild(StorePermissions.Brand.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StoreResource>(name);
    }
}
