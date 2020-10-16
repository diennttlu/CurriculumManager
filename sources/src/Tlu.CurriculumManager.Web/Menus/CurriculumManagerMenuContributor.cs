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
            if (!MultiTenancyConsts.IsEnabled)
            {
                var administration = context.Menu.GetAdministration();
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            var l = context.GetLocalizer<CurriculumManagerResource>();

            context.Menu.Items.Add(new ApplicationMenuItem(CurriculumManagerMenus.Home, l["Menu:Home"], "~/"));

            context.Menu.Items.Add(new ApplicationMenuItem(CurriculumManagerMenus.Home, l["Menu:SchoolYear"], "/SchoolYears"));

            context.Menu.Items.Add(new ApplicationMenuItem(CurriculumManagerMenus.Faculty, l["Menu:Faculty"], "/Faculties"));

            context.Menu.Items.Add(new ApplicationMenuItem(CurriculumManagerMenus.Major, l["Menu:Major"], "/Majors"));

            context.Menu.Items.Add(new ApplicationMenuItem(CurriculumManagerMenus.Curriculum, l["Menu:Curriculum"], "/Curriculums"));

            context.Menu.AddItem(new ApplicationMenuItem(CurriculumManagerMenus.Subject, l["Menu:Subject"])
                .AddItem(
                    new ApplicationMenuItem(CurriculumManagerMenus.Subjects.SubjectManagement, l["Menu:Subject.SubjectManagement"], "/Subjects")
                )
            );
        }
    }
}
