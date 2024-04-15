using AggregateRootEventTriggeringBug.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AggregateRootEventTriggeringBug.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AggregateRootEventTriggeringBugController : AbpControllerBase
{
    protected AggregateRootEventTriggeringBugController()
    {
        LocalizationResource = typeof(AggregateRootEventTriggeringBugResource);
    }
}
