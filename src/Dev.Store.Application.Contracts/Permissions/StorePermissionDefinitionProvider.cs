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

        var categoryPermission = myGroup.AddPermission(StorePermissions.Category.Default, L("Permission:Category"));
        categoryPermission.AddChild(StorePermissions.Category.Create, L("Permission:Create"));
        categoryPermission.AddChild(StorePermissions.Category.Update, L("Permission:Update"));
        categoryPermission.AddChild(StorePermissions.Category.Delete, L("Permission:Delete"));

        var locationPermission = myGroup.AddPermission(StorePermissions.Location.Default, L("Permission:Location"));
        locationPermission.AddChild(StorePermissions.Location.Create, L("Permission:Create"));
        locationPermission.AddChild(StorePermissions.Location.Update, L("Permission:Update"));
        locationPermission.AddChild(StorePermissions.Location.Delete, L("Permission:Delete"));

        var keywordPermission = myGroup.AddPermission(StorePermissions.Keyword.Default, L("Permission:Keyword"));
        keywordPermission.AddChild(StorePermissions.Keyword.Create, L("Permission:Create"));
        keywordPermission.AddChild(StorePermissions.Keyword.Update, L("Permission:Update"));
        keywordPermission.AddChild(StorePermissions.Keyword.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StoreResource>(name);
    }
}
