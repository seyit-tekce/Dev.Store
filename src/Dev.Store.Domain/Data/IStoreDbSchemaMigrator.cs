using System.Threading.Tasks;

namespace Dev.Store.Data;

public interface IStoreDbSchemaMigrator
{
    Task MigrateAsync();
}
