using Volo.Abp.Modularity;

namespace AggregateRootEventTriggeringBug;

public abstract class AggregateRootEventTriggeringBugApplicationTestBase<TStartupModule> : AggregateRootEventTriggeringBugTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
