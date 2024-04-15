using Volo.Abp.Modularity;

namespace AggregateRootEventTriggeringBug;

[DependsOn(
    typeof(AggregateRootEventTriggeringBugApplicationModule),
    typeof(AggregateRootEventTriggeringBugDomainTestModule)
)]
public class AggregateRootEventTriggeringBugApplicationTestModule : AbpModule
{

}
