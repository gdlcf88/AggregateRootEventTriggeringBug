using System;
using System.Collections.Generic;
using System.Text;
using AggregateRootEventTriggeringBug.Localization;
using Volo.Abp.Application.Services;

namespace AggregateRootEventTriggeringBug;

/* Inherit your application services from this class.
 */
public abstract class AggregateRootEventTriggeringBugAppService : ApplicationService
{
    protected AggregateRootEventTriggeringBugAppService()
    {
        LocalizationResource = typeof(AggregateRootEventTriggeringBugResource);
    }
}
