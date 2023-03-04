using Dev.Store.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

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

        var cloudinarySettingPermission = myGroup.AddPermission(StorePermissions.CloudinarySetting.Default, L("Permission:CloudinarySetting"));
        cloudinarySettingPermission.AddChild(StorePermissions.CloudinarySetting.Create, L("Permission:Create"));
        cloudinarySettingPermission.AddChild(StorePermissions.CloudinarySetting.Update, L("Permission:Update"));
        cloudinarySettingPermission.AddChild(StorePermissions.CloudinarySetting.Delete, L("Permission:Delete"));

        var uploadFilePermission = myGroup.AddPermission(StorePermissions.UploadFile.Default, L("Permission:UploadFile"));
        uploadFilePermission.AddChild(StorePermissions.UploadFile.Create, L("Permission:Create"));
        uploadFilePermission.AddChild(StorePermissions.UploadFile.Update, L("Permission:Update"));
        uploadFilePermission.AddChild(StorePermissions.UploadFile.Delete, L("Permission:Delete"));

        var productPermission = myGroup.AddPermission(StorePermissions.Product.Default, L("Permission:Product"));
        productPermission.AddChild(StorePermissions.Product.Create, L("Permission:Create"));
        productPermission.AddChild(StorePermissions.Product.Update, L("Permission:Update"));
        productPermission.AddChild(StorePermissions.Product.Delete, L("Permission:Delete"));

        var productSetPermission = myGroup.AddPermission(StorePermissions.ProductSet.Default, L("Permission:ProductSet"));
        productSetPermission.AddChild(StorePermissions.ProductSet.Create, L("Permission:Create"));
        productSetPermission.AddChild(StorePermissions.ProductSet.Update, L("Permission:Update"));
        productSetPermission.AddChild(StorePermissions.ProductSet.Delete, L("Permission:Delete"));

        var productSizePermission = myGroup.AddPermission(StorePermissions.ProductSize.Default, L("Permission:ProductSize"));
        productSizePermission.AddChild(StorePermissions.ProductSize.Create, L("Permission:Create"));
        productSizePermission.AddChild(StorePermissions.ProductSize.Update, L("Permission:Update"));
        productSizePermission.AddChild(StorePermissions.ProductSize.Delete, L("Permission:Delete"));

        var seoSettingPermission = myGroup.AddPermission(StorePermissions.SeoSetting.Default, L("Permission:SeoSetting"));
        seoSettingPermission.AddChild(StorePermissions.SeoSetting.Create, L("Permission:Create"));
        seoSettingPermission.AddChild(StorePermissions.SeoSetting.Update, L("Permission:Update"));
        seoSettingPermission.AddChild(StorePermissions.SeoSetting.Delete, L("Permission:Delete"));

        var productImagePermission = myGroup.AddPermission(StorePermissions.ProductImage.Default, L("Permission:ProductImage"));
        productImagePermission.AddChild(StorePermissions.ProductImage.Create, L("Permission:Create"));
        productImagePermission.AddChild(StorePermissions.ProductImage.Update, L("Permission:Update"));
        productImagePermission.AddChild(StorePermissions.ProductImage.Delete, L("Permission:Delete"));


        var management = context.AddGroup("Management", L("Permission:Administration"));
        management.AddPermission(StorePermissions.FileSettings.Default, L("Permission:FileSettings"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StoreResource>(name);
    }
}
