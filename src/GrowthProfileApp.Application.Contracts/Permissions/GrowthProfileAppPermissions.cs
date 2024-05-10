namespace GrowthProfileApp.Permissions;

public static class GrowthProfileAppPermissions
{
    public const string GroupName = "GrowthProfileApp";
    public const string TeacherGroupName = "TeacherGroup";
    public const string StudentGroupName = "StudentGroup";

    public static class TeacherPermissions
    {
        public const string Default = TeacherGroupName + ".Teachers";
        public const string View = Default + ".View";
        public const string Audit = Default + ".Audit";
    }

    public static class StudentPermissions
    {
        public const string Default = StudentGroupName + ".Students";
        public const string Write = Default + ".Write";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
    }
}
