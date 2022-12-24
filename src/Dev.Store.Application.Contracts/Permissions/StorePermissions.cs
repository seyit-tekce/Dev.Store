namespace Dev.Store.Permissions;

public static class StorePermissions
{
    public const string GroupName = "Store";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public class Brand
    {
        public const string Default = GroupName + ".Brand";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}
