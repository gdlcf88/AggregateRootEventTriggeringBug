using AggregateRootEventTriggeringBug.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AggregateRootEventTriggeringBug.Permissions;

public class AggregateRootEventTriggeringBugPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AggregateRootEventTriggeringBugPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AggregateRootEventTriggeringBugPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AggregateRootEventTriggeringBugResource>(name);
    }
}
