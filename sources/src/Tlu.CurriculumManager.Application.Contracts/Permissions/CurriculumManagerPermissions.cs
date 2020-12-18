namespace Tlu.CurriculumManager.Permissions
{
    public static class CurriculumManagerPermissions
    {
        public const string SubjectGroup = "SubjectManager";

        public static class Subjects
        {
            public const string Default = SubjectGroup + ".Subjects";
            public const string Create = SubjectGroup + ".Create";
            public const string Edit = SubjectGroup + ".Edit";
            public const string Delete = SubjectGroup + ".Delete";
        }

        public const string CurriculumGroup = "CurriculumManager";

        public static class Curriculums
        {
            public const string Default = CurriculumGroup + ".Curriculums";
            public const string Create = CurriculumGroup + ".Create";
            public const string Edit = CurriculumGroup + ".Edit";
            public const string Delete = CurriculumGroup + ".Delete";
        }

        public const string MajorGroup = "MajorManager";

        public static class Majors
        {
            public const string Default = MajorGroup + ".Majors";
            public const string Create = MajorGroup + ".Create";
            public const string Edit = MajorGroup + ".Edit";
            public const string Delete = MajorGroup + ".Delete";
        }


        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
    }
}