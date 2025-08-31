using System.ComponentModel.DataAnnotations;
namespace AttendancePayrollWebServerApp.Models.View
{
    public class LoginViewModel
    {
       [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter user name")]
        public string? UserName { get; set; } 

       [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter password")]
        public string? Password { get; set; }
    }
}
