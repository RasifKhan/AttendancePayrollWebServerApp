
using AttendancePayrollWebServerApp.Models;
public static class SessionHelper
{
    public static User CurrentUser { get; set; }
    public static bool IsLoggedIn => CurrentUser != null;

    public static void SetCurrentUser(string userName, int roleId, string access)
    {
        CurrentUser = new User
        {
        
            UserName = userName,
            RoleId = roleId,
            Access = access
        };
    }
    public static void Logout()
    {
        CurrentUser = null;
    }
}

