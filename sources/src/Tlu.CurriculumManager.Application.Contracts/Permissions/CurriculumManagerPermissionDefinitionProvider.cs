using Tlu.CurriculumManager.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Tlu.CurriculumManager.Permissions
{
    public class CurriculumManagerPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CurriculumManagerPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(CurriculumManagerPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CurriculumManagerResource>(name);
        }
    }
}
