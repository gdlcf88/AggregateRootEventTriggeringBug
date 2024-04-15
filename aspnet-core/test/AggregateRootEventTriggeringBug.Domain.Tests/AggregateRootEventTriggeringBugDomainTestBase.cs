using Volo.Abp.Modularity;

namespace AggregateRootEventTriggeringBug;

/* Inherit from this class for your domain layer tests. */
public abstract class AggregateRootEventTriggeringBugDomainTestBase<TStartupModule> : AggregateRootEventTriggeringBugTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
