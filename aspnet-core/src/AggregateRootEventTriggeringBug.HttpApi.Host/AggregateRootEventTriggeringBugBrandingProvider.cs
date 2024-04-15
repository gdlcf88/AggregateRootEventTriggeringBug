using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AggregateRootEventTriggeringBug;

[Dependency(ReplaceServices = true)]
public class AggregateRootEventTriggeringBugBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AggregateRootEventTriggeringBug";
}
