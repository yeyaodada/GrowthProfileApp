using GrowthProfileApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace GrowthProfileApp.Permissions;

public class GrowthProfileAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(GrowthProfileAppPermissions.GroupName);

        // Teacher group
        var teacherGroup = context.AddGroup(GrowthProfileAppPermissions.TeacherGroupName);

        var teacherPerms = teacherGroup.AddPermission(GrowthProfileAppPermissions.TeacherPermissions.Default);
        teacherPerms.AddChild(GrowthProfileAppPermissions.TeacherPermissions.View);
        teacherPerms.AddChild(GrowthProfileAppPermissions.TeacherPermissions.Audit);

        // Student group
        var studentGroup = context.AddGroup(GrowthProfileAppPermissions.StudentGroupName);

        var studentPerms = studentGroup.AddPermission(GrowthProfileAppPermissions.StudentPermissions.Default);
        studentPerms.AddChild(GrowthProfileAppPermissions.StudentPermissions.Write);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(GrowthProfileAppPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<GrowthProfileAppResource>(name);
    }
}
