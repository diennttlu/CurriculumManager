using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Tlu.CurriculumManager.Localization;
using Tlu.CurriculumManager.MultiTenancy;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Tlu.CurriculumManager.Web.Menus
{
    public class CurriculumManagerMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<CurriculumManagerResource>();
            if (!MultiTenancyConsts.IsEnabled)
            {
                var administration = context.Menu.GetAdministration();
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }
            
            context.Menu.GetAdministration().AddItem(new ApplicationMenuItem(CurriculumManagerMenus.Teachers.TeacherManagement, l["Menu:Teacher.TeacherManagement"], "/Teachers"));

            context.Menu.Items.Add(new ApplicationMenuItem(CurriculumManagerMenus.Home, l["Menu:Home"], "~/"));

            context.Menu.Items.Add(new ApplicationMenuItem(CurriculumManagerMenus.Home, l["Menu:SchoolYear"], "/SchoolYears"));

            context.Menu.Items.Add(new ApplicationMenuItem(CurriculumManagerMenus.Faculty, l["Menu:Faculty"])
                .AddItem(
                    new ApplicationMenuItem(CurriculumManagerMenus.Facultys.FacultyManagement, l["Menu:Faculty.FacultyManagement"], "/Faculties")
                ).AddItem(
                    new ApplicationMenuItem(CurriculumManagerMenus.Facultys.GenreManagement, l["Menu:Genre.GenreManagement"], "/Genres")
                )
            );

            context.Menu.Items.Add(new ApplicationMenuItem(CurriculumManagerMenus.Major, l["Menu:Major"], "/Majors"));

            context.Menu.Items.Add(new ApplicationMenuItem(CurriculumManagerMenus.Curriculum, l["Menu:Curriculum"])
                .AddItem(
                    new ApplicationMenuItem(CurriculumManagerMenus.Curriculums.CurriculumManagement, l["Menu:Curriculum.CurriculumManagement"], "/Curriculums")
                )
            );

            context.Menu.Items.Add(new ApplicationMenuItem(CurriculumManagerMenus.SubjectGroup, l["Menu:SubjectGroup"])
                .AddItem(
                    new ApplicationMenuItem(CurriculumManagerMenus.SubjectGroups.SubjectGroupManagement, l["Menu:SubjectGroup.SubjectGroupManagement"] , "/SubjectGroups")
                ).AddItem(
                    new ApplicationMenuItem(CurriculumManagerMenus.SubjectGroups.SubjectGroupDetail, l["Menu:SubjectGroup.Detail"], "/SubjectGroupDetails")
                )
           );

            context.Menu.AddItem(new ApplicationMenuItem(CurriculumManagerMenus.Subject, l["Menu:Subject"])
                .AddItem(
                    new ApplicationMenuItem(CurriculumManagerMenus.Subjects.SubjectManagement, l["Menu:Subject.SubjectManagement"], "/Subjects")
                ).AddItem(
                    new ApplicationMenuItem(CurriculumManagerMenus.Subjects.OutlineManagement, l["Menu:Subject.OutlineManagement"], "/Outlines")
                )
            );

            context.Menu.AddItem(new ApplicationMenuItem(CurriculumManagerMenus.Subject, l["Menu:Document"])
                .AddItem(
                    new ApplicationMenuItem(CurriculumManagerMenus.Documents.DocumentManagement, l["Menu:Document.DocumentManagement"], "/Documents")
                ).AddItem(
                    new ApplicationMenuItem(CurriculumManagerMenus.Documents.OutlineManagement, l["Menu:Document.OutlineManagement"], "/Outlines")
                )
            );
        }
    }
}
