using AttendancePayrollWebServerApp.Data;
using AttendancePayrollWebServerApp.Gateway;
using AttendancePayrollWebServerApp.Gateway.View;
using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Service.IService;
using AttendancePayrollWebServerApp.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AttendancePayrollWebServerApp;
using Microsoft.AspNetCore.Authentication.Cookies;
using AttendancePayrollWebServerApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDevExpressBlazor(options => {
    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
    options.SizeMode = DevExpress.Blazor.SizeMode.Medium;
});

// Register permission service
builder.Services.AddScoped<IUserPermissionService, UserPermissionService>();
builder.Services.AddScoped<IAuthorizationHandler, ModuleAuthorizationHandler>();

builder.Services.AddAuthorization(options =>
{
    // Add policies for each module
    var modules = new[] { "leavepage", "departmentpage", "companypage", "categorypage", "employeelist" };
    var permissions = new[] { UserPolicy.VIEW_PRODUCT, UserPolicy.ADD_PRODUCT, UserPolicy.EDIT_PRODUCT, UserPolicy.DELETE_PRODUCT };

    foreach (var module in modules)
    {
        foreach (var permission in permissions)
        {
            var policyName = $"{module}_{permission}";
            options.AddPolicy(policyName, policy =>
                policy.Requirements.Add(new ModuleRequirement(module, permission)));
        }

        // Default policy for page access (VIEW permission)
        options.AddPolicy($"{module}_Access", policy =>
            policy.Requirements.Add(new ModuleRequirement(module, UserPolicy.VIEW_PRODUCT)));
    }
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/Account/Login";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        options.AccessDeniedPath = "/accessdenied";
    });

builder.Services.AddCascadingAuthenticationState();

// Add all your existing services
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<ShiftDetailGateway>();
builder.Services.AddTransient<DepartmentGateway>();
builder.Services.AddTransient<CategoryGateway>();
builder.Services.AddTransient<CategoryItemGateway>();
builder.Services.AddTransient<DesignationGateway>();
builder.Services.AddTransient<CompanyGateway>();
builder.Services.AddTransient<SectionGateway>();
builder.Services.AddTransient<SalarySectionGateway>();
builder.Services.AddTransient<EmployeeGateway>();
builder.Services.AddTransient<LeaveGateway>();
builder.Services.AddTransient<FixDayGateway>();
builder.Services.AddTransient<HolidayGateway>();
builder.Services.AddTransient<AttendanceGateway>();
builder.Services.AddTransient<FixAttendanceGateway>();
builder.Services.AddTransient<EmployeeBankAccInfoGateway>();
builder.Services.AddTransient<FixAttendanceInstantGateway>();
builder.Services.AddTransient<FixAttendanceViewGateway>();
builder.Services.AddTransient<UserRoleGateway>();
builder.Services.AddTransient<AttendanceSummaryViewGateway>();
builder.Services.AddTransient<JobCardViewGateway>();
builder.Services.AddTransient<UserGateway>();
builder.Services.AddTransient<UserModuleGateway>();
builder.Services.AddTransient<Gateway>();
builder.Services.AddTransient<AttendanceViewGateway>();
builder.Services.AddTransient<SalaryViewGateway>();
builder.Services.AddTransient<AttendanceDashboardGateway>();
builder.Services.AddTransient<ShiftMasterGateway>();
builder.Services.AddTransient<SalaryBreakdownSetupGateway>();
builder.Services.AddTransient<FixAttendanceBackupGateway>();
builder.Services.AddTransient<ReportConstringGateway>();
builder.Services.AddTransient<UserAccountGateway>();
builder.Services.AddTransient<UserAccountPolicyGateway>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IFileUpload, FileUpload>();

builder.WebHost.UseWebRoot("wwwroot");
builder.WebHost.UseStaticWebAssets();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllers();

app.Run();





//using AttendancePayrollWebServerApp.Data;
//using AttendancePayrollWebServerApp.Gateway;
//using AttendancePayrollWebServerApp.Gateway.View;
//using AttendancePayrollWebServerApp.Models;
//using AttendancePayrollWebServerApp.Service.IService;
//using AttendancePayrollWebServerApp.Service;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Components.Authorization;
//using AttendancePayrollWebServerApp.Helper;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
//builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
//builder.Services.AddServerSideBlazor();

//builder.Services.AddDevExpressBlazor(options =>
//{
//    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
//    options.SizeMode = DevExpress.Blazor.SizeMode.Medium;
//});

//// ------------------- Authorization -------------------



//builder.Services.AddAuthorization(options =>
//{
//    foreach (var userPolicy in UserPolicy.GetPolicies())
//    {
//        options.AddPolicy(userPolicy, policy =>
//            policy.RequireClaim(userPolicy, "true"));
//    }

//    options.AddPolicy("ModulePolicy", policy =>
//        policy.RequireAssertion(context =>
//        {
//            string path = null;

//            // Try to get HttpContext path
//            if (context.Resource is HttpContext httpContext)
//                path = httpContext.Request.Path.Value;
//            else if (context.Resource is Microsoft.AspNetCore.Http.Endpoint endpoint)
//                path = endpoint.DisplayName;

//            if (string.IsNullOrEmpty(path))
//                return false; // deny if path unknown

//            path = path.ToLowerInvariant();

//            // Hard-coded mapping of URL → module
//            var moduleMappings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
//            {
//                { "/leavepage", "Leave" },
//                // Only Leave page is allowed as hard-coded for now
//            };

//            // Check if path matches any mapped module
//            foreach (var kvp in moduleMappings)
//            {
//                if (path.Contains(kvp.Key))
//                {
//                    string module = kvp.Value;

//                    // Allow access only if user has ModuleAccess claim
//                    return context.User.Claims.Any(c =>
//                        c.Type == "ModuleAccess" &&
//                        c.Value.StartsWith($"{module}:", StringComparison.OrdinalIgnoreCase));
//                }
//            }

//            // If page is not mapped → block access (Department, Payroll, etc.)
//            return false;
//        }));
//});



//// ------------------- Authentication -------------------
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.Cookie.Name = "auth_token";
//        options.LoginPath = "/Account/Login";
//        options.AccessDeniedPath = "/accessdenied";
//        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
//        options.Cookie.HttpOnly = true;
//        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//    });

//builder.Services.AddCascadingAuthenticationState();

//// ------------------- Gateways -------------------
//builder.Services.AddSingleton<WeatherForecastService>();
//builder.Services.AddTransient<ShiftDetailGateway>();
//builder.Services.AddTransient<DepartmentGateway>();
//builder.Services.AddTransient<CategoryGateway>();
//builder.Services.AddTransient<CategoryItemGateway>();
//builder.Services.AddTransient<DesignationGateway>();
//builder.Services.AddTransient<CompanyGateway>();
//builder.Services.AddTransient<SectionGateway>();
//builder.Services.AddTransient<SalarySectionGateway>();
//builder.Services.AddTransient<EmployeeGateway>();
//builder.Services.AddTransient<LeaveGateway>();
//builder.Services.AddTransient<FixDayGateway>();
//builder.Services.AddTransient<HolidayGateway>();
//builder.Services.AddTransient<AttendanceGateway>();
//builder.Services.AddTransient<FixAttendanceGateway>();
//builder.Services.AddTransient<EmployeeBankAccInfoGateway>();
//builder.Services.AddTransient<FixAttendanceInstantGateway>();
//builder.Services.AddTransient<FixAttendanceViewGateway>();
//builder.Services.AddTransient<UserRoleGateway>();
//builder.Services.AddTransient<AttendanceSummaryViewGateway>();
//builder.Services.AddTransient<JobCardViewGateway>();
//builder.Services.AddTransient<UserGateway>();
//builder.Services.AddTransient<UserModuleGateway>();
//builder.Services.AddTransient<Gateway>();
//builder.Services.AddTransient<AttendanceViewGateway>();
//builder.Services.AddTransient<SalaryViewGateway>();
//builder.Services.AddTransient<AttendanceDashboardGateway>();
//builder.Services.AddTransient<ShiftMasterGateway>();
//builder.Services.AddTransient<SalaryBreakdownSetupGateway>();
//builder.Services.AddTransient<FixAttendanceBackupGateway>();
//builder.Services.AddTransient<ReportConstringGateway>();
//builder.Services.AddTransient<UserAccountGateway>();
//builder.Services.AddTransient<UserAccountPolicyGateway>();

//builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<IFileUpload, FileUpload>();

//builder.WebHost.UseWebRoot("wwwroot");
//builder.WebHost.UseStaticWebAssets();

//var app = builder.Build();

//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    app.UseHsts();
//}

//// Debug: Print claims
//app.Use(async (context, next) =>
//{
//    Console.WriteLine("Current User Claims:");
//    foreach (var claim in context.User.Claims)
//        Console.WriteLine($"  {claim.Type}: {claim.Value}");
//    await next();
//});

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapRazorPages();
//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");
//app.MapControllers();

//app.Run();














