using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using AttendancePayrollWebServerApp.Gateway;
using AttendancePayrollWebServerApp.Models;
namespace AttendancePayrollWebServerApp.Helper
{

    public static class SD
    {
        //public const string x = "Super Admin";

        //public const string Rolee_SuperAdmin = x;

        //public const string Role_Admin = "Admin";
        //public const string Role_QuotationUser = "Quot User";
        //public const string Role_InventoryUser = "Invt User";
        //public const string Role_RoleTest = "Role Test";


        // public  string y = "Super Admin";

        // public static readonly string Role_SuperAdmin = "Super Admin";

        public static string x = "Super Admin";

        public static string Role_SuperAdmin { get; set; } = x;


        private static List<UserRole> userRoles = new List<UserRole>();






       
        //private static readonly Lazy<string> _dynamicRole1 = new Lazy<string>(() => GetRoleSync(0));
        //private static readonly Lazy<string> _dynamicRole2 = new Lazy<string>(() => GetRoleSync(1));
        //private static readonly Lazy<string> _dynamicRole3 = new Lazy<string>(() => GetRoleSync(2));
        //private static readonly Lazy<string> _dynamicRole4 = new Lazy<string>(() => GetRoleSync(3));
        //Public const-like properties
        //public static string DynamicRole1 => _dynamicRole1.Value;
        //public static string DynamicRole2 => _dynamicRole2.Value;
        //public static string DynamicRole3 => _dynamicRole3.Value;
        //public static string DynamicRole4 => _dynamicRole4.Value;


        //public static string DynamicRole1 => userRoles.Count > 0 ? userRoles[0].RoleName : string.Empty;



        // public const string constDynamicRole1 = DynamicRole1.ToString();    //"k";// DynamicRole1



        //private static string GetRoleSync(int index)
        //{
        //    try
        //    {
        //        var roles = UserRoleGateway.GetUserRoleListStatic().GetAwaiter().GetResult();
        //        return roles.Count > index ? roles[index].RoleName : string.Empty;
        //    }
        //    catch
        //    {
        //        return string.Empty;
        //    }
        //}






























        public static async Task<List<UserRole>> GetUserRoles(string condition = "")
        {
            userRoles = await UserRoleGateway.GetUserRoleListStatic(condition);
            return userRoles;
        }



    }
}
