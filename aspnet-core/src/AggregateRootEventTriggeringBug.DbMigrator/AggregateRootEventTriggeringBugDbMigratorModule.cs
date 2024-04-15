using AggregateRootEventTriggeringBug.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AggregateRootEventTriggeringBug.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AggregateRootEventTriggeringBugEntityFrameworkCoreModule),
    typeof(AggregateRootEventTriggeringBugApplicationContractsModule)
    )]
public class AggregateRootEventTriggeringBugDbMigratorModule : AbpModule
{
}
