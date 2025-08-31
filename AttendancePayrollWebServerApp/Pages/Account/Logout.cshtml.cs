using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AttendancePayrollWebServerApp.Pages.Account
{
    public class LogoutModel : PageModel
    {
        //public async Task<IActionResult> OnGetAsync()
        //{
        //    //// Sign out the user and clear the authentication cookie
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        //    //// Redirect to the login page
        //    return RedirectToPage("/Account/Login");
        //}


        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Account/Login", new { ReturnUrl = returnUrl ?? "/" });
        }


    }
}




//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;

//namespace AttendancePayrollWebServerApp.Pages.Account
//{
//    public class LogoutModel : PageModel
//    {
//        public void OnGet()
//        {
//        }
//    }
//}
