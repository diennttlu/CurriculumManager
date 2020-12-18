using Tlu.CurriculumManager.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Tlu.CurriculumManager.Permissions
{
    public class CurriculumManagerPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var subjectGroup = context.AddGroup(CurriculumManagerPermissions.SubjectGroup, L("Học phần"));
            var subjectPermission = subjectGroup.AddPermission(CurriculumManagerPermissions.Subjects.Default, L("Quản lý học phần"));
            subjectPermission.AddChild(CurriculumManagerPermissions.Subjects.Create, L("Thêm học phần"));
            subjectPermission.AddChild(CurriculumManagerPermissions.Subjects.Edit, L("Sửa học phần"));
            subjectPermission.AddChild(CurriculumManagerPermissions.Subjects.Delete, L("Xóa học phần"));

            //Define your own permissions here. Example:
            //myGroup.AddPermission(CurriculumManagerPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CurriculumManagerResource>(name);
        }
    }
}
