using AttendancePayrollWebServerApp.Gateway;
using AttendancePayrollWebServerApp.Models.View;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AttendancePayrollWebServerApp.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserAccountGateway _userAccountGateway;
        private readonly NavigationManager _navigationManager;

        public LoginModel(UserAccountGateway userAccountGateway,
                          NavigationManager navigationManager)
        {
            _userAccountGateway = userAccountGateway;
            _navigationManager = navigationManager;
        }

        [BindProperty]
        public LoginViewModel Model { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? ReturnUrl { get; set; }

        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
            ReturnUrl ??= "/";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Please correct the form errors";
                return Page();
            }

            if (string.IsNullOrWhiteSpace(Model.UserName) || string.IsNullOrWhiteSpace(Model.Password))
            {
                ErrorMessage = "Invalid User Name or Password";
                return Page();
            }

            var userAccountList = await _userAccountGateway.GetUserAccountList();
            var userAccount = userAccountList.FirstOrDefault(x =>
                x.UserName.Equals(Model.UserName, StringComparison.OrdinalIgnoreCase));

            if (userAccount == null)
            {
                ErrorMessage = "Invalid User Name or Password";
                return Page();
            }

            string inputUserName = Model.UserName ?? string.Empty;
            string inputPassword = Model.Password ?? string.Empty;
            string result = await _userAccountGateway.Login(inputUserName, inputPassword);

            if (result == "failed")
            {
                ErrorMessage = "Invalid User Name or Password";
                return Page();
            }

            // Create simple claims - permissions will be checked dynamically
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, Model.UserName),
                new Claim("UserAccountId", userAccount.UserAccountId.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);

            if (!string.IsNullOrEmpty(ReturnUrl) && Uri.TryCreate(ReturnUrl, UriKind.RelativeOrAbsolute, out var uri))
            {
                if (uri.IsAbsoluteUri)
                {
                    ReturnUrl = uri.PathAndQuery;
                }
            }

            return LocalRedirect(ReturnUrl ?? "/");
        }
    }
}


//using AttendancePayrollWebServerApp.Gateway;
//using AttendancePayrollWebServerApp.Models.View;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.Security.Claims;

//namespace AttendancePayrollWebServerApp.Pages.Account
//{
//    [AllowAnonymous]
//    public class LoginModel : PageModel
//    {
//        private readonly UserAccountGateway _userAccountGateway;
//        private readonly UserAccountPolicyGateway _userAccountPolicyGateway;
//        private readonly NavigationManager _navigationManager;

//        public LoginModel(
//            UserAccountGateway userAccountGateway,
//            UserAccountPolicyGateway userAccountPolicyGateway,
//            NavigationManager navigationManager)
//        {
//            _userAccountGateway = userAccountGateway;
//            _userAccountPolicyGateway = userAccountPolicyGateway;
//            _navigationManager = navigationManager;
//        }

//        [BindProperty]
//        public LoginViewModel Model { get; set; } = new();

//        [BindProperty(SupportsGet = true)]
//        public string? ReturnUrl { get; set; }

//        public string? ErrorMessage { get; set; }

//        public void OnGet()
//        {
//            ReturnUrl ??= "/";
//        }

//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (!ModelState.IsValid)
//            {
//                ErrorMessage = "Please correct the form errors";
//                return Page();
//            }

//            if (string.IsNullOrWhiteSpace(Model.UserName) || string.IsNullOrWhiteSpace(Model.Password))
//            {
//                ErrorMessage = "Invalid User Name or Password";
//                return Page();
//            }

//            var userAccountList = await _userAccountGateway.GetUserAccountList();
//            var userAccount = userAccountList.FirstOrDefault(x =>
//                x.UserName.Equals(Model.UserName, StringComparison.OrdinalIgnoreCase));

//            if (userAccount == null)
//            {
//                ErrorMessage = "Invalid User Name or Password";
//                return Page();
//            }

//            string inputUserName = Model.UserName ?? string.Empty;
//            string inputPassword = Model.Password ?? string.Empty;
//            string result = await _userAccountGateway.Login(inputUserName, inputPassword);

//            if (result == "failed")
//            {
//                ErrorMessage = "Invalid User Name or Password";
//                return Page();
//            }

//            // ------------------- Hard-coded Claims for Testing -------------------
//            var claims = new List<Claim>
//            {
//                new Claim(ClaimTypes.Name, Model.UserName),
//                new Claim("UserAccountId", userAccount.UserAccountId.ToString()),
//                new Claim("ModuleAccess", "Leave:View")   // <-- THIS MAKES LEAVEPAGE ACCESSIBLE
//            };

//            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//            var principal = new ClaimsPrincipal(identity);

//            await HttpContext.SignInAsync(
//                CookieAuthenticationDefaults.AuthenticationScheme,
//                principal,
//                new AuthenticationProperties { IsPersistent = true });

//            ReturnUrl ??= "/";
//            return LocalRedirect(ReturnUrl);
//        }
//    }
//}


