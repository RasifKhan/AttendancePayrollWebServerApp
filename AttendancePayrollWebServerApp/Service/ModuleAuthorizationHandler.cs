
using AttendancePayrollWebServerApp.Service.IService;
using AttendancePayrollWebServerApp.Service;
using Microsoft.AspNetCore.Authorization;
namespace AttendancePayrollWebServerApp.Service;
public class ModuleAuthorizationHandler : AuthorizationHandler<ModuleRequirement>
{
    private readonly IUserPermissionService _permissionService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ModuleAuthorizationHandler(
        IUserPermissionService permissionService,
        IHttpContextAccessor httpContextAccessor)
    {
        _permissionService = permissionService;
        _httpContextAccessor = httpContextAccessor;
    }

    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        ModuleRequirement requirement)
    {
        var userIdClaim = context.User.FindFirst("UserAccountId");
        if (userIdClaim == null)
        {
            context.Fail();
            return;
        }

        var userId = userIdClaim.Value;
        var hasPermission = await _permissionService.HasPermissionAsync(
            userId,
            requirement.Module,
            requirement.Permission);

        if (hasPermission)
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
    }
}


//namespace AttendancePayrollWebServerApp.Service
//{
//    public class ModuleAuthorizationHandler
//    {
//    }
//}
