namespace Dev.Store.Permissions;

public static class StorePermissions
{

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    public const string GroupName = "Store";
    public class Brand
    {
        public const string Default = "Brand";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class Category
    {
        public const string Default = "Category";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class Location
    {
        public const string Default = "Location";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class Keyword
    {
        public const string Default = "Keyword";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class CloudinarySetting
    {
        public const string Default = GroupName + ".CloudinarySetting";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class UploadFile
    {
        public const string Default = GroupName + ".UploadFile";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class Product
    {
        public const string Default = GroupName + ".Product";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class ProductSet
    {
        public const string Default = GroupName + ".ProductSet";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class ProductSize
    {
        public const string Default = GroupName + ".ProductSize";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class SeoSetting
    {
        public const string Default = GroupName + ".SeoSetting";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class ProductImage
    {
        public const string Default = GroupName + ".ProductImage";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    public class FileSettings
    {
        public const string Default = GroupName + ".FileSettings";
    }
}
