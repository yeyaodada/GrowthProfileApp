using System.Threading.Tasks;

namespace GrowthProfileApp.Data;

public interface IGrowthProfileAppDbSchemaMigrator
{
    Task MigrateAsync();
}
