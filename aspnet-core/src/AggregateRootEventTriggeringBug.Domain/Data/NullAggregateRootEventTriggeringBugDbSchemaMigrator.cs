using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AggregateRootEventTriggeringBug.Data;

/* This is used if database provider does't define
 * IAggregateRootEventTriggeringBugDbSchemaMigrator implementation.
 */
public class NullAggregateRootEventTriggeringBugDbSchemaMigrator : IAggregateRootEventTriggeringBugDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
