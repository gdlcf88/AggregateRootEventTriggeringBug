using Volo.Abp.Settings;

namespace AggregateRootEventTriggeringBug.Settings;

public class AggregateRootEventTriggeringBugSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AggregateRootEventTriggeringBugSettings.MySetting1));
    }
}
