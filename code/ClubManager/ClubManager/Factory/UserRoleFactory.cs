namespace ClubManager.Factory
{
    public static class UserRoleFactory
    {
        public static string GetDashboardPage(string role)
        {
            switch (role)
            {
                case "Admin":
                    return "DashboardAdmin.aspx";

                case "Entraineur":
                    return "DashboardEntraineur.aspx";

                default:
                    return "";
            }
        }
    }
}