using Volo.Abp.Modularity;

namespace AggregateRootEventTriggeringBug;

[DependsOn(
    typeof(AggregateRootEventTriggeringBugDomainModule),
    typeof(AggregateRootEventTriggeringBugTestBaseModule)
)]
public class AggregateRootEventTriggeringBugDomainTestModule : AbpModule
{

}
