using AttendancePayrollWebServerApp.Gateway;
using AttendancePayrollWebServerApp.Helper;
using AttendancePayrollWebServerApp.Service.IService;
namespace AttendancePayrollWebServerApp.Service;
public class UserPermissionService : IUserPermissionService
{
    private readonly UserAccountPolicyGateway _userAccountPolicyGateway;

    public UserPermissionService(UserAccountPolicyGateway userAccountPolicyGateway)
    {
        _userAccountPolicyGateway = userAccountPolicyGateway;
    }

    public async Task<bool> HasPageAccessAsync(string userId, string module)
    {
        var policies = await _userAccountPolicyGateway.GetUserAccountPolicyList();
        return policies.Any(p =>
            p.UserAccountId.ToString() == userId &&
            p.Module.Equals(module, StringComparison.OrdinalIgnoreCase) &&
            p.UserPolicy == UserPolicy.VIEW_PRODUCT &&
            p.IsEnabled);
    }

    public async Task<bool> HasPermissionAsync(string userId, string module, string permission)
    {
        var policies = await _userAccountPolicyGateway.GetUserAccountPolicyList();
        return policies.Any(p =>
            p.UserAccountId.ToString() == userId &&
            p.Module.Equals(module, StringComparison.OrdinalIgnoreCase) &&
            p.UserPolicy == permission &&
            p.IsEnabled);
    }

    public async Task<Dictionary<string, List<string>>> GetUserModulePermissionsAsync(string userId)
    {
        var policies = await _userAccountPolicyGateway.GetUserAccountPolicyList();
        var userPolicies = policies.Where(p =>
            p.UserAccountId.ToString() == userId &&
            p.IsEnabled).ToList();

        return userPolicies
            .GroupBy(p => p.Module)
            .ToDictionary(
                g => g.Key,
                g => g.Select(p => p.UserPolicy).ToList()
            );
    }
}









//namespace AttendancePayrollWebServerApp.Service
//{
//    public class UserPermissionService
//    {
//    }
//}
