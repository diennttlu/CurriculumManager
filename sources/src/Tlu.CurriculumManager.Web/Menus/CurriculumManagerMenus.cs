namespace Tlu.CurriculumManager.Web.Menus
{
    public class CurriculumManagerMenus
    {
        private const string Prefix = "CurriculumManager";

        public const string Home = Prefix + ".Home";

        public const string Faculty = Prefix + ".Faculty";

        public const string Genre = Prefix + ".Genre";

        public const string Major = Prefix + ".Major";

        public const string SchoolYear = Prefix + ".SchoolYear";

        public const string Curriculum = Prefix + ".Curriculum";

        public static class Facultys
        {
            public const string FacultyManagement = Faculty + ".FacultyManagement";
            public const string GenreManagement = Genre + ".GenreManagement";
        }

        public static class Curriculums
        {
            public const string CurriculumManagement = Curriculum + ".CurriculumManagement";

            public const string CurriculumDetail = Curriculum + ".CurriculumDetail";
        }

        public const string SubjectGroup = Prefix + ".SubjectGroup";
        
        public static class SubjectGroups
        {
            public const string SubjectGroupManagement = SubjectGroup + ".SubjectGroupManagement";

            public const string SubjectGroupDetail = SubjectGroup + ".SubjectGroupDetail";
        }
        
        public const string Subject = Prefix + ".Subject";
        public static class Subjects
        {
            public const string SubjectManagement = Subject + ".SubjectManagement";
        }
        //Add your menu items here...

    }
}