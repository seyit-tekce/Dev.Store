using Dev.Store.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Dev.Store.Permissions;

public class StorePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {


        var brandPermissionGroup = context.AddGroup(StorePermissions.Brand.Default);
        var brandPermission = brandPermissionGroup.AddPermission(StorePermissions.Brand.Default, L("Permission:Brand"));
        brandPermission.AddChild(StorePermissions.Brand.Create, L("Permission:Create"));
        brandPermission.AddChild(StorePermissions.Brand.Update, L("Permission:Update"));
        brandPermission.AddChild(StorePermissions.Brand.Delete, L("Permission:Delete"));


        var categoryPermissionGroup = context.AddGroup(StorePermissions.Category.Default);
        var categoryPermission = categoryPermissionGroup.AddPermission(StorePermissions.Category.Default, L("Permission:Category"));
        categoryPermission.AddChild(StorePermissions.Category.Create, L("Permission:Create"));
        categoryPermission.AddChild(StorePermissions.Category.Update, L("Permission:Update"));
        categoryPermission.AddChild(StorePermissions.Category.Delete, L("Permission:Delete"));

        var locationPermissionGroup = context.AddGroup(StorePermissions.Location.Default);
        var locationPermission = locationPermissionGroup.AddPermission(StorePermissions.Location.Default, L("Permission:Location"));
        locationPermission.AddChild(StorePermissions.Location.Create, L("Permission:Create"));
        locationPermission.AddChild(StorePermissions.Location.Update, L("Permission:Update"));
        locationPermission.AddChild(StorePermissions.Location.Delete, L("Permission:Delete"));

        var keywordPermissionGroup = context.AddGroup(StorePermissions.Keyword.Default);
        var keywordPermission = keywordPermissionGroup.AddPermission(StorePermissions.Keyword.Default, L("Permission:Keyword"));
        keywordPermission.AddChild(StorePermissions.Keyword.Create, L("Permission:Create"));
        keywordPermission.AddChild(StorePermissions.Keyword.Update, L("Permission:Update"));
        keywordPermission.AddChild(StorePermissions.Keyword.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StoreResource>(name);
    }
}
