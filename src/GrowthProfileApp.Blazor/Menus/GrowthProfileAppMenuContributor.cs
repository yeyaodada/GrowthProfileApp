using System.Threading.Tasks;
using GrowthProfileApp.Localization;
using GrowthProfileApp.Permissions;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace GrowthProfileApp.Blazor.Menus;

public class GrowthProfileAppMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task<Task> ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<GrowthProfileAppResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                GrowthProfileAppMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );

        administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        if (await context.IsGrantedAsync(GrowthProfileAppPermissions.StudentPermissions.Default))
        {
            var docManagementMenu = new ApplicationMenuItem(
                "DocManagement",
                "学生档案管理",
                icon: "fa fa-file-text"
            );

            if (await context.IsGrantedAsync(GrowthProfileAppPermissions.StudentPermissions.Write))
            {
                docManagementMenu.AddItem(
                    new ApplicationMenuItem(
                        "InfoEditor",
                        "个人信息编辑",
                        url: "/Document/EditInfo",
                        icon: "fa fa-pencil"
                    )
                );
                docManagementMenu.AddItem(
                    new ApplicationMenuItem(
                        "DocEditor", 
                        "档案编辑（第一学年）", 
                        url: "/Document/Editor/1", 
                        icon: "fa fa-pencil"
                    )
                );
                docManagementMenu.AddItem(
                    new ApplicationMenuItem(
                        "DocEditor",
                        "档案编辑（第二学年）",
                        url: "/Document/Editor/2",
                        icon: "fa fa-pencil"
                    )
                );
                docManagementMenu.AddItem(
                    new ApplicationMenuItem(
                        "DocEditor",
                        "档案编辑（第三学年）",
                        url: "/Document/Editor/3",
                        icon: "fa fa-pencil"
                    )
                );
                docManagementMenu.AddItem(
                    new ApplicationMenuItem(
                        "DocEditor",
                        "档案编辑（第四学年）",
                        url: "/Document/Editor/4",
                        icon: "fa fa-pencil"
                    )
                );

            }

            context.Menu.AddItem(docManagementMenu);
        }

        if (await context.IsGrantedAsync(GrowthProfileAppPermissions.TeacherPermissions.Default))
        {
            var docAuditMenu = new ApplicationMenuItem(
                "DocAudit",
                "学生档案审阅",
                icon: "fa fa-cogs"
            );

            if (await context.IsGrantedAsync(GrowthProfileAppPermissions.TeacherPermissions.Audit))
            {
                docAuditMenu.AddItem(
                    new ApplicationMenuItem(
                        "DocAuditManager",
                        "档案审核",
                        url: "/Document/AuditList",
                        icon: "fa fa-gavel"
                    )
                );
            }

            context.Menu.AddItem(docAuditMenu);
        }

        return Task.CompletedTask;
    }
}
