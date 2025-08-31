namespace AttendancePayrollWebServerApp.Service.IService;
public interface IUserPermissionService
{
    Task<bool> HasPageAccessAsync(string userId, string module);
    Task<bool> HasPermissionAsync(string userId, string module, string permission);
    Task<Dictionary<string, List<string>>> GetUserModulePermissionsAsync(string userId);
}



//namespace AttendancePayrollWebServerApp.Service.IService
//{
//    public interface IUserPermissionService
//    {
//    }
//}
