using System.Threading.Tasks;

namespace AggregateRootEventTriggeringBug.Data;

public interface IAggregateRootEventTriggeringBugDbSchemaMigrator
{
    Task MigrateAsync();
}
