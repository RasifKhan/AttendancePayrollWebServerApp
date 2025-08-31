
using AttendancePayrollWebServerApp.Helper;
using Microsoft.AspNetCore.Authorization;
namespace AttendancePayrollWebServerApp.Service;

public class ModuleRequirement : IAuthorizationRequirement
{
    public string Module { get; }
    public string Permission { get; }

    public ModuleRequirement(string module, string permission = UserPolicy.VIEW_PRODUCT)
    {
        Module = module;
        Permission = permission;
    }
}



//namespace AttendancePayrollWebServerApp.Service
//{
//    public class ModuleRequirement
//    {
//    }
//}
