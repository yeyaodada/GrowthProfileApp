using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace GrowthProfileApp.Data;

/* This is used if database provider does't define
 * IGrowthProfileAppDbSchemaMigrator implementation.
 */
public class NullGrowthProfileAppDbSchemaMigrator : IGrowthProfileAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
