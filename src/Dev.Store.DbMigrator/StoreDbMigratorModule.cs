using Dev.Store.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Dev.Store.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(StoreEntityFrameworkCoreModule),
    typeof(StoreApplicationContractsModule)
    )]
public class StoreDbMigratorModule : AbpModule
{

}
