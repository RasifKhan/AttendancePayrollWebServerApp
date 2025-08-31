using AttendancePayrollWebServerApp.Gateway;
using Microsoft.AspNetCore.Authorization;
using System.Data;

public class CustomAuthorizeAttribute : AuthorizeAttribute
{
    public CustomAuthorizeAttribute(params string[] roleKeys)
    {
        var roles = LoadRolesFromDatabase(roleKeys);
        Roles = string.Join(",", roles);
    }

    public int TestName { get; set; }
    private string[] LoadRolesFromDatabase(string[] roleKeys)
    {
        return roleKeys.Select(key => GetRoleFromDb(key)).ToArray();
    }



    private string GetRoleFromDb(string roleKey)
    {
        try
        {
            //  Use your gateway to get the role
            //  Use your gateway to get the role


            var task = UserRoleGateway.GetRoleFromDbStatic(roleKey);
            task.Wait(); 
            // Note: This is synchronous call in async context

            return task.Result;

        }
        catch (Exception)
        {
            return roleKey; // Fallback to original key if error
        }
    }
}








//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Data;

//public class CustomAuthorizeAttribute : AuthorizeAttribute
//{


//    public CustomAuthorizeAttribute(params string[] roleKeys)
//    {
//        //Load roles from database based on keys
//        var roles = LoadRolesFromDatabase(roleKeys);
//        Roles = string.Join(",", roles);
//    }



//    private string[] LoadRolesFromDatabase(string[] roleKeys)
//    {
//        // Your database logic here
//        return roleKeys.Select(key => GetRoleFromDb(key)).ToArray();
//    }


//    private string GetRoleFromDb(string roleKey)
//    {
//        // Get service provider from HttpContext (if available)
//        var serviceProvider = HttpContextAccessor.Current?.RequestServices;
//        if (serviceProvider != null)
//        {
//            using var dbContext = serviceProvider.GetRequiredService<YourDbContext>();
//            var role = dbContext.Roles.FirstOrDefault(r => r.Key == roleKey);
//            return role?.Name ?? roleKey;
//        }
//        return roleKey; // Fallback
//    }


//}


